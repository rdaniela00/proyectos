from django.urls import path
#lammaos a las vistas
from core.user.views import *


app_name='user' 

urlpatterns = [
   path('list/', UserListView.as_view(), name='user_list'),#podemos ponerle nombre a las url
   path('add/', UserCreateView.as_view(), name='user_create'),
   path('update/<int:pk>/', UserUpdateView.as_view(), name='user_update'),
   path('delete/<int:pk>/', UserDeleteView.as_view(), name='user_delete'),
   path('change/group/<int:pk>/', UserChangeGroup.as_view(), name='user_change_group'),
   path('perfil/', UserPerfilView.as_view(), name='user_perfil'),
   path('change/password/', UserChangePasswordView.as_view(), name='user_change_password'),
   ]