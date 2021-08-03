from django.views.generic import TemplateView
from django.http import JsonResponse
from django.contrib.auth.decorators import login_required
from django.views.decorators.csrf import csrf_protect, csrf_exempt
from django.utils.decorators import method_decorator
from core.erp.forms import TestForm
from core.erp.models import Product, Category


class TestView(TemplateView):
    template_name = 'tests.html'

    @method_decorator(csrf_exempt)
    @method_decorator(login_required)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            action = request.POST['action']
            if action == 'search_product_id':
                data = [{'id': '', 'text': '----------------'}]
                for i in Product.objects.filter(cat_id=request.POST['id']):
                    data.append({'id': i.id, 'text': i.name})
            elif action == 'autocomplete':
                #data sera un array
                data = []
                #lo que contiene la variable de tst.html me llega la term y 0a10 registros
                for i in Category.objects.filter(name__icontains=request.POST['term'][0:10]):
                    item = i.toJSON()
                    item['value']= i.name
                    data.append(item)
            else:
                data['error'] = 'Ha ocurrido un error'
        except Exception as e:
         data['error'] = str(e)
        return JsonResponse(data, safe=False)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Select Aninados | Django'
        context['form'] = TestForm()
        return context