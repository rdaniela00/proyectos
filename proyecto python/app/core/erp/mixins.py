from datetime import datetime
from crum import get_current_request
from django.contrib import messages
from django.http import HttpResponseRedirect
from django.shortcuts import redirect
from django.urls import reverse_lazy
#permite tener la session actual del usuario
from crum import get_current_request
from django.contrib.auth.models import Group

class IsSuperuserMixin(object):
	#Él método dispatch es el que ejecuta al inicio de una vista, tiene como
	# función principal redireccionar ya sea si es por get o post dependiendo la petición que realices en tu vista. 
	# Ya sea que hagas un get o post siempre pasara por el método dispatch. 
    def dispatch(self, request, *args, **kwargs):
        if request.user.is_superuser:
            return super().dispatch(request, *args, **kwargs)
        return redirect('index')

        #enviar valores adicionales
    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['date_now'] = datetime.now()
        return context 
#clase object es clase base de todas las clases, permiso, redireccionamos 
class ValidatePermissionRequiredMixin(object):
    permission_required = ''
    url_redirect = None

    #OBTENER LOS PERMISOS QUE LLEGAN DE LA VISTA
    def get_perms(self):
        perms = []
        #convierto la tupla en un solo valor, else envio toda la tupla
        if isinstance(self.permission_required, str):
           perms.append(self.permission_required)
        else:
            perms = list(self.permission_required)
        return perms

    #me redirecciona a una pagina en caso que no tenga permiso
    def get_url_redirect(self):
        if self.url_redirect is None:
            return reverse_lazy('erp:dashboard')
        return self.url_redirect

    def dispatch(self, request, *args, **kwargs):
        request = get_current_request()
        if request.user.is_superuser:
            return super().dispatch(request, *args, **kwargs)
        if 'group' in request.session:
            group = request.session['group']
            perms = self.get_perms()
            for p in perms:
                if not group.permissions.filter(codename=p).exists():
                    messages.error(request, 'No tiene permiso para ingresar a este módulo')
                    return HttpResponseRedirect(self.get_url_redirect())
            return super().dispatch(request, *args, **kwargs)
        messages.error(request, 'No tiene permiso para ingresar a este módulo')
        return HttpResponseRedirect(self.get_url_redirect())
      
        


#class ValidatePermissionRequiredMixin(object):
 #   permission_required = ''
  #  url_redirect = None

#OBTENER LOS PERMISOS QUE LLEGAN DE LA VISTA
   # def get_perms(self):
        #convierto la tupla en un solo valor, else envio toda la tupla
    #    if isinstance(self.permission_required, str):
     #       perms = (self.permission_required,)
      #  else:
         #   perms = self.permission_required
        #return perms

    #def get_url_redirect(self):
     #   if self.url_redirect is None:
      #      return reverse_lazy('login')
      #      return reverse_lazy('login')
      #      return reverse_lazy('login')
       #  return self.url_redirect

    # def dispatch(self, request, *args, **kwargs):
      #   if request.user.has_perms(self.get_perms()):
        #     return super().dispatch(request, *args, **kwargs)
        # messages.error(request, 'No tiene permiso para ingresar a este modùlo')
        # return redirect(self.get_url_redirect())

       



