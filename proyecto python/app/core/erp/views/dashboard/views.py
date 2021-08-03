from django.db.models import Sum
from django.db.models.functions import Coalesce
from django.views.generic import TemplateView
from datetime import datetime
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_protect, csrf_exempt
from django.http import JsonResponse
from django.contrib.auth.mixins import LoginRequiredMixin

from core.erp.models import Sale, Product, DetSale
from crum import get_current_user


class DashboardView(LoginRequiredMixin,TemplateView):
    template_name = 'dashboard.html'


    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def get(self, request, *args, **kwargs):
        #trae el grupo actual
        request.user.get_group_session()
        return super().get(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            action = request.POST['action']
            if action == 'get_graph_sales_year_month':
                data = self.get_graph_sales_year_month()
            elif action == 'get_graph_sale_products_mes':
            	data= self.get_graph_sale_products_mes()
                
            else: 
                data['error'] + 'Ha ocurrido un error'
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data, safe= False)

#grafico de ventas al año por mes
    def get_graph_sales_year_month(self):
        data = []
        try:
            year = datetime.now().year
            for m in range(1, 13):
                total = Sale.objects.filter(date_joined__year=year, date_joined__month=m,user_creation_id=get_current_user()).aggregate(r=Coalesce(Sum('total'), 0)).get('r')
                data.append(float(total))
        except:
            pass
        return data
    def get_graph_sale_products_mes(self):
        data = []
        year = datetime.now().year
        month = datetime.now().month
        try:
            for p in Product.objects.all().filter(user_creation_id=get_current_user()):
                total = DetSale.objects.filter(sale__date_joined__year=year, sale__date_joined__month=month,
                                               prod_id=p.id).aggregate(
                    r=Coalesce(Sum('subtotal'), 0)).get('r')
                if total > 0:
                    data.append({
                        'name': p.name,
                        'y': float(total)
                    })
        except:
            pass
        return data
    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['panel'] = 'Panel de administrador'
        context['graph_sales_year_month'] = self.get_graph_sales_year_month()
        return context
