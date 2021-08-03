from django.contrib.auth.decorators import login_required
from django.contrib.auth.mixins import LoginRequiredMixin, PermissionRequiredMixin
from django.http import JsonResponse, HttpResponseRedirect
from django.contrib.auth.models import Group
from django.shortcuts import render, redirect
from django.urls import reverse_lazy
from django.views.decorators.csrf import csrf_protect, csrf_exempt
#importamos las visats genericas para crear 
from django.views.generic import ListView, CreateView, UpdateView, DeleteView, FormView, View
from django.utils.decorators import method_decorator
from core.erp.mixins import IsSuperuserMixin, ValidatePermissionRequiredMixin
from core.user.forms import UserForm, UserPerfilForm
from core.user.models import User
from django.contrib.auth.forms import PasswordChangeForm
from django.contrib.auth import update_session_auth_hash



class UserListView(LoginRequiredMixin, ValidatePermissionRequiredMixin,ListView):

	#para listar objeto
    model = User
    #cual es la plantilla
    template_name = 'user/list.html'
    #trabajamos con mixins
    permission_required = 'view_user'

    @method_decorator(csrf_exempt)
    # @method_decorator(login_required)#para mantenerte logeuado y cerra sesion el mixlogin es
    #dispach para redireccionar el tipo de peticion que se haga
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)
        
    def post(self, request, *args, **kwargs):
        data = {}
        try:
            action = request.POST['action']
            if action == 'searchdata':
            	data = []
            	for i in User.objects.all():
            		data.append(i.toJSON())
            else: 
            	data['error'] + 'Ha ocurrido un error'
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data, safe= False)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Listado de Usuarios'
        context['create_url'] = reverse_lazy('user:user_create')
        context['list_url'] = reverse_lazy('user:user_list')
        context['entity'] = 'Usuarios'
        return context


class UserCreateView(LoginRequiredMixin, ValidatePermissionRequiredMixin, CreateView):
    model = User
    form_class = UserForm
    template_name = 'user/create.html'
    success_url = reverse_lazy('user:user_list')
    permission_required = 'add_user'
    url_redirect = success_url

    @method_decorator(csrf_exempt)
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
        context['title'] = 'Creación de un Usuario'
        context['entity'] = 'Usuarios'
        context['list_url'] = self.success_url
        context['action'] = 'add'
        return context


class UserUpdateView(LoginRequiredMixin, ValidatePermissionRequiredMixin,UpdateView):
    #modelo categoria 
    model = User
    #el form lo trae de form.py 
    form_class = UserForm
    template_name = 'user/create.html'
    #redireccionamos a otra plantilla
    success_url = reverse_lazy('user:user_list')
    permission_required = 'change_user'
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
        context['title'] = 'Edición de un Usuario'
        context['entity'] = 'Uusuarios'
        context['list_url'] = self.success_url
        context['action'] = 'edit'
        return context

class UserDeleteView(LoginRequiredMixin, ValidatePermissionRequiredMixin, DeleteView):
    model = User
    template_name = 'user/delete.html'
    #retornar una vez que la eliminacion sea exitosa
    success_url = reverse_lazy('user:user_list')
    permission_required = 'delete_user'
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
        context['title'] = 'Eliminación de un Usuario'
        context['entity'] = 'Usuarios'
        context['list_url'] = self.success_url
        return context

class UserChangeGroup(LoginRequiredMixin, View):

    def get(self, request, *args, **kwargs):
        try:
            request.session['group'] = Group.objects.get(pk=self.kwargs['pk'])
        except :
            pass
        return HttpResponseRedirect(reverse_lazy('erp:dashboard'))


class UserPerfilView(LoginRequiredMixin,UpdateView):
    #modelo categoria 
    model = User
    #el form lo trae de form.py 
    form_class = UserPerfilForm
    template_name = 'user/perfil.html'
    #redireccionamos a otra plantilla
    success_url = reverse_lazy('erp:dashboard')
    
    #decimos que la clase object va ser igual a lo que tenemos en la instacia del objeto
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        self.object = self.get_object()
        return super().dispatch(request, *args, **kwargs)
    #id actual
    def get_object(self, queryset=None):
        return self.request.user



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
        context['title'] = 'Edición de Perfil'
        context['entity'] = 'Perfil'
        context['list_url'] = self.success_url
        context['action'] = 'edit'
        return context 


class UserChangePasswordView(LoginRequiredMixin, FormView):
    #modelo categoria 
    model = User
    #el passworchangeform lo crea django formulario
    form_class = PasswordChangeForm
    template_name = 'user/change_password.html'
    #redireccionamos a otra plantilla
    success_url = reverse_lazy('login')
    
    #decimos que la clase object va ser igual a lo que tenemos en la instacia del objeto
    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get_form(self, form_class=None):
        #usuario actual
        form = PasswordChangeForm(user=self.request.user)
        form.fields['old_password'].widget.attrs['placeholder'] = 'Ingrese su Contraseña Actual'
        form.fields['new_password1'].widget.attrs['placeholder'] = 'Ingrese su nueva Contraseña'
        form.fields['new_password2'].widget.attrs['placeholder'] = 'Repita su Contraseña'
        return form

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            action = request.POST['action']
            #si if es igual a dd iniciara procesos
            if action == 'edit':
                form = PasswordChangeForm(user=request.user, data=request.POST)
                if form.is_valid():
                    form.save()
                    #para que no se cierre sesión actual
                    update_session_auth_hash(request, form.user)
                else:
                    data['error'] = form.errors
            else:
                data['error'] = 'No ha ingresado a ninguna opción'
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data)
     #context data para parametoris adicionales    
    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Edición de Password'
        context['entity'] = 'Password'
        context['list_url'] = self.success_url
        context['action'] = 'edit'
        return context 