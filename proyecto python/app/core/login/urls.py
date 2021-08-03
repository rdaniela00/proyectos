from django.urls import path
from core.login.views import *


urlpatterns = [
    path('', LoginFormView2.as_view(), name='login'),
    #llamo directamente a logout y una ves que cierra sesion se va a el login por en next_page dentro de view
    #path('logout/', LogoutView.as_view(), name='logout'),
    path('logout/', LogoutRedirectView.as_view(), name='logout'),
    path('reset/password/', RestablecerpasswordView.as_view(), name='reset_password'),
    path('change/password/<str:token>/', CambioPasswordView.as_view(), name='change_password'),
    
  
]