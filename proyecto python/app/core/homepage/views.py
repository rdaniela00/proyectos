from django.shortcuts import render
#vista generica
from django.views.generic import TemplateView

# Create your views here. templateview renderiza una plantilla

class IndexView(TemplateView):
	template_name = 'index.html'
