#contendra los formularios
from django.forms import *


class ReportForm(Form):
    date_range = CharField( widget=TextInput(attrs={
        'class': 'form-control',
        'autocomplate': 'off'
    }))