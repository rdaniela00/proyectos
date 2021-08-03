from django.urls import path
#lammaos a las vistas
from core.erp.views.category.views import *
from core.erp.views.mesa.views import *
from core.erp.views.client.views import *
from core.erp.views.dashboard.views import *
from core.erp.views.product.views import *
from core.erp.views.tests.views import TestView
from core.erp.views.sale.views import *

app_name='erp' 

urlpatterns = [
   path('category/list/', CategoryListView.as_view(), name='category_list'),#podemos ponerle nombre a las url
   path('category/add/', CategoryCreateView.as_view(), name='category_create'),
   path('category/update/<int:pk>/', CategoryUpdateView.as_view(), name='category_update'),
   path('category/delete/<int:pk>/', CategoryDeleteView.as_view(), name='category_delete'),
   #path('category/form/', CategoryFormView.as_view(), name='category_form'),
   # product
   path('product/list/', ProductListView.as_view(), name='product_list'),
   path('product/add/', ProductCreateView.as_view(), name='product_create'),
   path('product/update/<int:pk>/', ProductUpdateView.as_view(), name='product_update'),
   path('product/delete/<int:pk>/', ProductDeleteView.as_view(), name='product_delete'),

   # client
    path('client/list/', ClientListView.as_view(), name='client_list'),
    path('client/add/', ClientCreateView.as_view(), name='client_create'),
    path('client/update/<int:pk>/', ClientUpdateView.as_view(), name='client_update'),
    path('client/delete/<int:pk>/', ClientDeleteView.as_view(), name='client_delete'),
   #dasboard
   path('dashboard/', DashboardView.as_view(), name='dashboard'),
   #tests
   path('test/', TestView.as_view(), name='test'),
   # mesas
   path('mesa/list/', MesaListView.as_view(), name='mesa_list'),#podemos ponerle nombre a las url
   path('mesa/add/', MesaCreateView.as_view(), name='mesa_create'),
   path('mesa/update/<int:pk>/', MesaUpdateView.as_view(), name='mesa_update'),
   path('mesa/delete/<int:pk>/', MesaDeleteView.as_view(), name='mesa_delete'),

   #saleventas
   path('sale/add/', SaleCreateView.as_view(), name='sale_create'),
   path('sale/list/', SaleListView.as_view(), name='sale_list'),
   path('sale/delete/<int:pk>/', SaleDeleteView.as_view(), name='sale_delete'),
   path('sale/factura/pdf/<int:pk>/', SaleinvoicePdfView.as_view(), name='sale_invoice'),



]