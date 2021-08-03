from django.contrib.auth.decorators import login_required
from django.contrib.auth.mixins import LoginRequiredMixin, PermissionRequiredMixin
from django.contrib.auth.models import User
from django.http import JsonResponse, HttpResponseRedirect
from django.shortcuts import render, redirect
from django.urls import reverse_lazy
from django.views.decorators.csrf import csrf_protect, csrf_exempt
#importamos las visats genericas para crear 
from django.views.generic import ListView, CreateView, UpdateView, DeleteView, FormView
from django.utils.decorators import method_decorator
from core.erp.mixins import IsSuperuserMixin, ValidatePermissionRequiredMixin
from core.erp.forms import CategoryForm
from core.erp.models import Category
from crum import get_current_user



class CategoryListView(LoginRequiredMixin, ValidatePermissionRequiredMixin,ListView):

	#para listar objeto
    model = Category
    #cual es la plantilla
    template_name = 'category/list.html'
    permission_required = 'view_category'

    @method_decorator(csrf_exempt)
    # @method_decorator(login_required)#para mantenerte logeuado y cerra sesion el mixlogin es
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
        
    def post(self, request, *args, **kwargs):
        data = {}
        try:
        	#ATRIBUTO ACTION DEL POST Y CUANDO MANEJSAS POST ES NECESARIO TENER IDENTIFICADOR que es el searchdata
        	#la variable data viene siendo en este caso un array, despues con el for intero los elementos de mi categoria
        	#lueg incrusto todos los elementos en mi array
            action = request.POST['action']
            if action == 'searchdata':
            	data = []
            	for i in Category.objects.all().filter(user_creation_id=get_current_user()):
            		data.append(i.toJSON())
            else: 
            	data['error'] + 'Ha ocurrido un error'
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data, safe= False)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Listado de Categorías'
        context['create_url'] = reverse_lazy('erp:category_create')
        context['list_url'] = reverse_lazy('erp:category_list')
        context['entity'] = 'Categorias'
        return context


class CategoryCreateView(ValidatePermissionRequiredMixin,CreateView):
    model = Category
    #el form lo trae de form.py 
    form_class = CategoryForm
    template_name = 'category/create.html'
    #redireccionamos a otra plantilla
    success_url = reverse_lazy('erp:category_list')
    permission_required = 'add_category'
    url_redirect = success_url

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            action = request.POST['action']
            #si if es igual a dd iniciara procesos
            if action == 'add':
            	#lo guardamos en el form si es valido l guardamos
                form = self.get_form()
                data = form.save()
            else:
                data['error'] = 'No ha ingresado a ninguna opción'
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data)

    #     print(request.POST)
    #     form = CategoryForm(request.POST)
    #     if form.is_valid():
    #         form.save()
    #         return HttpResponseRedirect(self.success_url)
    #     self.object = None
    #     context = self.get_context_data(**kwargs)
    #     context['form'] = form
    #     return render(request, self.template_name, context)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Creación una Categoria'
        context['entity'] = 'Categorias'
        context['list_url'] = self.success_url
        #la acction es cuando se utiliza el ajax
        context['action'] = 'add'
        return context

#creamos la clase a la cual le aplicamos la view generica
class CategoryUpdateView(LoginRequiredMixin, ValidatePermissionRequiredMixin,UpdateView):
	#modelo categoria 
    model = Category
    #el form lo trae de form.py 
    form_class = CategoryForm
    template_name = 'category/create.html'
    #redireccionamos a otra plantilla
    success_url = reverse_lazy('erp:category_list')
    permission_required = 'change_category'
    url_redirect = success_url
    #decimos que la clase object va ser igual a lo que tenemos en la instacia del objeto
    def dispatch(self, request, *args, **kwargs):
        self.object = self.get_object()
        return super().dispatch(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            action = request.POST['action']
            #si if es igual a dd iniciara procesos
            if action == 'edit':
            	#si if es igual a dd iniciara procesos
                form = self.get_form()
                data = form.save()
            else:
                data['error'] = 'No ha ingresado a ninguna opción'
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data)
     #context data para parametoris adicionales    
    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Edición una Categoria'
        context['entity'] = 'Categorias'
        context['list_url'] = self.success_url
        context['action'] = 'edit'
        return context
	
class CategoryDeleteView(LoginRequiredMixin, ValidatePermissionRequiredMixin, DeleteView):
    model = Category
    template_name = 'category/delete.html'
    #retornar una vez que la eliminacion sea exitosa
    success_url = reverse_lazy('erp:category_list')
    permission_required = 'delete_category'
    url_redirect = success_url

    #@method_decorator(csrf_exempt)
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
        context['title'] = 'Eliminación de una Categoria'
        context['entity'] = 'Categorias'
        context['list_url'] = self.success_url
        return context







