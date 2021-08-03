from django.urls import path
from core.reports.views import ReportfacturaView
urlpatterns = [
#reports
   path('sale/', ReportfacturaView.as_view(), name='sale_report'),
   ]