from django.contrib.auth import login, logout
from django.contrib.auth.views import LoginView, LogoutView
from django.contrib.auth.forms import AuthenticationForm
import uuid
from django.views.generic import FormView
from django.shortcuts import redirect
from django.urls import reverse_lazy
from django.shortcuts import HttpResponseRedirect
from django.http import JsonResponse
import app.settings as setting
from core.login.forms import RestablecerpasswordForm, CambiopasswordForm
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_protect, csrf_exempt
from app.wsgi import *
import smtplib
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText

from django.template.loader import render_to_string
from app import settings
from app import settings
from core.user.models import User
#clase y por form ambas class funcionan 
#class LoginFormView(LoginView):
	#template_name = 'login.html'
#probar inicio de sesion si lo tengo abierto
	#def dispatch(self, request, *args, **kwargs):
		#saber, si usuario esta en sesion o logueado hacer que se redireccionee
		#if request.user.is_authenticated:
			#return redirect(setting.LOGIN_REDIRECT_URL)

		#return super().dispatch(request, *args, **kwargs)


#conext para enviar mas parametros a mi template
	#def get_context_data(self, **kwargs):
		#variable para recuperar lo que ya tiene el context
		#context = super().get_context_data(**kwargs)
		#context['title']= 'Iniciar Sesión'
		#return context

class LoginFormView2(FormView):
	#forview trabaja con formulario
	form_class=AuthenticationForm
	template_name = 'login.html'
	success_url= reverse_lazy(setting.LOGIN_REDIRECT_URL)
	#probar inicio de sesion si lo tengo abierto
	def dispatch(self, request, *args, **kwargs):
		#saber, si usuario esta en sesion o logueado hacer que se redireccionee
		if request.user.is_authenticated:
			return HttpResponseRedirect(self.success_url)

		return super().dispatch(request, *args, **kwargs)

	def form_valid(self, form):
		login(self.request, form.get_user())
		return HttpResponseRedirect(self.success_url)


	#conext para enviar mas parametros a mi template
	def get_context_data(self, **kwargs):
		#variable para recuperar lo que ya tiene el context
		context = super().get_context_data(**kwargs)
		context['title']= 'Iniciar Sesión'
		return context

#otra forma de cerrar sesion 
class LogoutRedirectView(LogoutView):
	pattern_name= 'login'

	def dispatch(self, request, *args, **kwargs):
		logout(request)
		return super().dispatch(request, *args, **kwargs)

class RestablecerpasswordView(FormView):
    form_class = RestablecerpasswordForm
    template_name = 'login/resetpassword.html'
    success_url = reverse_lazy(setting.LOGIN_REDIRECT_URL)

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def send_email_restablecer_password(self, user):
        data = {}
        try:
            URL = settings.DOMAIN if not settings.DEBUG else self.request.META['HTTP_HOST']
            user.token = uuid.uuid4()
            user.save()

            mailServer = smtplib.SMTP(settings.EMAIL_HOST, settings.EMAIL_PORT)
            mailServer.starttls()
            mailServer.login(settings.EMAIL_HOST_USER, settings.EMAIL_HOST_PASSWORD)

            email_to = user.email
            mensaje = MIMEMultipart()
            mensaje['From'] = settings.EMAIL_HOST_USER
            mensaje['To'] = email_to
            mensaje['Subject'] = 'Reseteo de contraseña'

            content = render_to_string('login/send_email.html', {
                'user': user,
                'link_resetpwd': 'http://{}/login/change/password/{}/'.format(URL, str(user.token)),
                'link_home': 'http://{}'.format(URL)
            })
            mensaje.attach(MIMEText(content, 'html'))

            mailServer.sendmail(settings.EMAIL_HOST_USER,
                                email_to,
                                mensaje.as_string())
        except Exception as e:
            data['error'] = str(e)
        return data

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            form = RestablecerpasswordForm(request.POST) #=SELF.GET.FORM
            #si for es valido envia el correo
            if form.is_valid():
            	#usuario actual
            	user = form.get_user()
            	#envio correo
            	data = self.send_email_restablecer_password(user)
            else:
            	data['error'] = form.errors
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data, safe=False)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Reseteo de Contraseña'
        return context


class CambioPasswordView(FormView):
    form_class = CambiopasswordForm
    template_name = 'login/changepassword.html'
    success_url = reverse_lazy(setting.LOGIN_REDIRECT_URL)

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, *args, **kwargs):
        token = self.kwargs['token']
        if User.objects.filter(token=token).exists():
            return super().get(request, *args, **kwargs)
        return HttpResponseRedirect('/')

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            form = CambiopasswordForm(request.POST)
            if form.is_valid():
                user = User.objects.get(token=self.kwargs['token'])
                user.set_password(request.POST['password'])
                user.token = uuid.uuid4()
                user.save()
            else:
                data['error'] = form.errors
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data, safe=False)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Cambio de Contraseña'
        context['login_url'] = settings.LOGIN_URL
        return context

	
