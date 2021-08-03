from django.contrib.auth.decorators import login_required
from django.contrib.auth.mixins import LoginRequiredMixin
from django.http import JsonResponse, HttpResponseRedirect
from django.shortcuts import render, redirect
from django.urls import reverse_lazy
from django.views.decorators.csrf import csrf_protect, csrf_exempt
#importamos las visats genericas para crear 
from django.views.generic import ListView, CreateView, UpdateView, DeleteView, FormView
from django.utils.decorators import method_decorator
from core.erp.mixins import IsSuperuserMixin, ValidatePermissionRequiredMixin
from core.erp.forms import MesaForm
from core.erp.models import Mesa
from crum import get_current_user


class MesaListView(LoginRequiredMixin, ValidatePermissionRequiredMixin,ListView):
    model = Mesa
    template_name = 'mesa/list.html'
    permission_required = 'view_mesa'

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            #ATRIBUTO ACTION DEL POST Y CUANDO MANEJAS POST ES NECESARIO TENER IDENTIFICADOR que es el searchdata
            #la variable data viene siendo en este caso un array, despues con el for intero los elementos de mi categoria
            #lueg incrusto todos los elementos en mi array
            action = request.POST['action']
            if action == 'searchdata':
                data = []
                for i in Mesa.objects.all().filter(user_creation_id=get_current_user()):

                    data.append(i.toJSON())
            else: 
                data['error'] + 'Ha ocurrido un error'
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data, safe= False)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Listado de Mesas'
        context['create_url'] = reverse_lazy('erp:mesa_create')
        context['list_url'] = reverse_lazy('erp:mesa_list')
        context['entity'] = 'Mesas'
        return context


class MesaCreateView(LoginRequiredMixin, ValidatePermissionRequiredMixin,CreateView):
    model = Mesa
    form_class = MesaForm
    template_name = 'mesa/create.html'
    success_url = reverse_lazy('erp:mesa_list')
    permission_required = 'add_mesa'
    url_redirect = success_url

    @method_decorator(login_required)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            action = request.POST['action']
            if action == 'add':
                form = self.get_form()
                data = form.save()
            else:
                data['error'] = 'No ha ingresado a ninguna opción'
        except Exception as e:
           data['error'] = str(e)
        return JsonResponse(data)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Creación de una Mesa'
        context['entity'] = 'Mesas'
        context['list_url'] = self.success_url
        context['action'] = 'add'
        return context


class MesaUpdateView(LoginRequiredMixin, ValidatePermissionRequiredMixin,UpdateView):
    model = Mesa
    form_class = MesaForm
    template_name = 'mesa/create.html'
    success_url = reverse_lazy('erp:mesa_list')
    permission_required = 'change_mesa'
    url_redirect = success_url

    @method_decorator(login_required)
    def dispatch(self, request, *args, **kwargs):
        self.object = self.get_object()
        return super().dispatch(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            action = request.POST['action']
            if action == 'edit':
                form = self.get_form()
                data = form.save()
            else:
                data['error'] = 'No ha ingresado a ninguna opción'
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Edición de una Mesa'
        context['entity'] = 'Mesas'
        context['list_url'] = self.success_url
        context['action'] = 'edit'
        return context


class MesaDeleteView(LoginRequiredMixin, ValidatePermissionRequiredMixin,DeleteView):
    model = Mesa
    template_name = 'mesa/delete.html'
    success_url = reverse_lazy('erp:mesa_list')
    permission_required = 'delete_mesa'
    url_redirect = success_url

    @method_decorator(login_required)
    def dispatch(self, request, *args, **kwargs):
        self.object = self.get_object()
        return super().dispatch(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            self.object.delete()
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Eliminación de una mesa'
        context['entity'] = 'Mesas'
        context['list_url'] = self.success_url
        return context
