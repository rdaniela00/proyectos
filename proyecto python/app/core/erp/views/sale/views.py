import json

from django.contrib.auth.mixins import LoginRequiredMixin
from django.db import transaction
from django.http import JsonResponse, HttpResponse, HttpResponseRedirect
from django.urls import reverse_lazy
from django.utils.decorators import method_decorator
from django.views.decorators.csrf import csrf_exempt

from core.erp.forms import SaleForm,ClientForm
from core.erp.mixins import ValidatePermissionRequiredMixin
from django.views.generic import CreateView, ListView, DeleteView, View

from core.erp.models import Sale, Product, DetSale, company, Client, Mesa

import os
from django.db.models import Q
from django.conf import settings
from django.http import HttpResponse
from django.template.loader import get_template
from xhtml2pdf import pisa
from django.contrib.staticfiles import finders
from crum import get_current_user


class SaleListView(LoginRequiredMixin, ValidatePermissionRequiredMixin, ListView):
    model = Sale
    template_name = 'sale/list.html'
    permission_required = 'view_sale'

    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            action = request.POST['action']
            if action == 'searchdata':
                data = []
                for i in Sale.objects.all().filter(user_creation_id=get_current_user()):
                    data.append(i.toJSON())
            elif action == 'search_details_prod':
                data = []
                for i in DetSale.objects.filter(sale_id=request.POST['id']):
                    data.append(i.toJSON())
            else:
                data['error'] = 'Ha ocurrido un error'
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data, safe=False)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Listado de Ventas'
        context['list_url'] = reverse_lazy('erp:sale_list')
        context['entity'] = 'Ventas'
        return context
class SaleCreateView(LoginRequiredMixin, ValidatePermissionRequiredMixin, CreateView):
    model = Sale
    form_class = SaleForm
    template_name = 'sale/create.html'
    success_url = reverse_lazy('erp:dashboard')
    permission_required = 'add_sale'
    url_redirect = success_url


    @method_decorator(csrf_exempt)
    def dispatch(self, request, *args, **kwargs):
        return super().dispatch(request, *args, **kwargs)

    def post(self, request, *args, **kwargs):
        data = {}
        try:
            action = request.POST['action']
            if action == 'search_products':
                data = []
                #conv a lista con loads
                ids_exculde= json.loads(request.POST['ids'])
                term = request.POST['term'].strip()
                products = Product.objects.filter(stock__gt=0, user_creation_id=get_current_user())
                if len(term):
                    products = products.filter(name__icontains=term)
                for i in products.exclude(id__in=ids_exculde)[0:10]:
                    item = i.toJSON()
                    item['value'] = i.name
                    #item['text'] = i.name
                    data.append(item)
            elif action == 'search_autocomplete':
                data = []
                #conv a lista con loads
                ids_exculde= json.loads(request.POST['ids'])
              
                term = request.POST['term'].strip()
                data.append({'id':term, 'text': term})
                products = Product.objects.filter(name__icontains=term, stock__gt=0, user_creation_id=get_current_user())
                #in que mande rangos 
                for i in products.exclude(id__in=ids_exculde)[0:10]:
                    item = i.toJSON()
                    item['text'] = i.name
                    data.append(item)
            elif action == 'add':
                with transaction.atomic():
                    vents = json.loads(request.POST['vents'])
                    sale = Sale()
                    sale.date_joined = vents['date_joined']
                    sale.cli_id = vents['cli']
                    sale.tables_id = vents['tables']
                    sale.subtotal = float(vents['subtotal'])
                    sale.iva = float(vents['iva'])
                    sale.total = float(vents['total'])
                    sale.pagorecibio = float(vents['pagorecibio'])
                    sale.pagocambio = float(vents['pagocambio'])
                    sale.save()
                    for i in vents['products']:
                        det = DetSale()
                        det.sale_id = sale.id
                        det.prod_id = i['id']
                        det.cant = int(i['cant'])
                        det.price = float(i['pvp'])
                        det.subtotal = float(i['subtotal'])
                        det.save()
                        #stock se disminuya de input cantidad
                        det.prod.stock -= det.cant
                        det.prod.save()
                    data ={'id': sale.id}
            elif action == 'search_clients':
                data = []
                term = request.POST['term']
                clients = Client.objects.filter(Q(names__icontains=term) | Q(surnames__icontains=term) | Q(phone__icontains=term), user_creation_id=get_current_user())[0:10]
                for i in clients:
                    item = i.toJSON()
                    item['text'] = i.get_full_name()
                    data.append(item)
            elif action == 'create_client':
                with transaction.atomic():
                    frmClient = ClientForm(request.POST)
                    data = frmClient.save()
            else:
                data['error'] = 'No ha ingresado a ninguna opción'
        except Exception as e:
            data['error'] = str(e)
        return JsonResponse(data, safe=False)

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context['title'] = 'Creación de una Venta'
        context['entity'] = 'Ventas'
        context['list_url'] = self.success_url
        context['action'] = 'add'
        context['frmClient'] = ClientForm()
        return context


class SaleDeleteView(LoginRequiredMixin, ValidatePermissionRequiredMixin, DeleteView):
    model = Sale
    template_name = 'sale/delete.html'
    success_url = reverse_lazy('erp:sale_list')
    permission_required = 'delete_sale'
    url_redirect = success_url

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
        context['title'] = 'Eliminación de una Venta'
        context['entity'] = 'Ventas'
        context['list_url'] = self.success_url
        return context


class SaleinvoicePdfView(View):

    def link_callback(self, uri, rel):
        """
        Convert HTML URIs to absolute system paths so xhtml2pdf can access those
        resources
        """
        # use short variable names
        sUrl = settings.STATIC_URL  # Typically /static/
        sRoot = settings.STATIC_ROOT  # Typically /home/userX/project_static/
        mUrl = settings.MEDIA_URL  # Typically /static/media/
        mRoot = settings.MEDIA_ROOT  # Typically /home/userX/project_static/media/

        # convert URIs to absolute system paths
        if uri.startswith(mUrl):
            path = os.path.join(mRoot, uri.replace(mUrl, ""))
        elif uri.startswith(sUrl):
            path = os.path.join(sRoot, uri.replace(sUrl, ""))
        else:
            return uri  # handle absolute uri (ie: http://some.tld/foo.png)

        # asegúrese de que el archivo exista
        if not os.path.isfile(path):
            raise Exception(
                'media URI must start with %s or %s' % (sUrl, mUrl)
            )
        return path

    def get(self, request, *args, **kwargs):
        try:
            template = get_template('sale/invoice.html')
            context = {
                'sale': Sale.objects.get(pk=self.kwargs['pk']),
                'comp': company.objects.get(user_creation_id=get_current_user()),
                'icon': '{}{}'.format(settings.STATIC_URL, 'img/logos.png')
             }

            html = template.render(context)
            response = HttpResponse(content_type='application/pdf')
            #linea para que se descargue el pdf
            #response['Content-Disposition'] = 'attachment; filename="report.pdf"'
            pisaStatus = pisa.CreatePDF(
                html, dest=response,
                link_callback=self.link_callback
            )
            
            return response
        except:
            pass
        return HttpResponseRedirect(reverse_lazy('erp:sale_list'))

