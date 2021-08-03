#contendra los formularios
from django.forms import *
from datetime import datetime
from django import forms
from crum import get_current_user
from core.erp.models import Category,Product,Client, Mesa, Sale


class CategoryForm(ModelForm):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        #for form in self.visible_fields():
            #form.field.widget.attrs['class'] = 'form-control'
            #form.field.widget.attrs['autocomplete'] = 'off'
        self.fields['name'].widget.attrs['autofocus'] = True

    class Meta:
        model = Category
        fields = '__all__'
        widgets = {
            'name': TextInput(
                attrs={
                    'placeholder': 'Ingrese un nombre',
                }
            ),
            'desc': Textarea(
                attrs={
                    'placeholder': 'Ingrese una descripción',
                    'rows': 3,
                    'cols': 3
                }
            ),
        }
        #excluir del form quien lo creo y modifico
        exclude = ['user_updated', 'user_creation']

    def save(self, commit=True):
    	data={}
    	form = super()
    	try:
    		if form.is_valid():
    			form.save()
    		else:
    			data['error']=form.errors
    	except Exception as e:
    		data['error'] = str(e)
    	return data
    		
class ProductForm(ModelForm):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.fields['name'].widget.attrs['autofocus'] = True
        self.fields['cat'].queryset = Category.objects.all().filter(user_creation_id=get_current_user())

    class Meta:
        model = Product
        fields = '__all__'
        widgets = {
            'name': TextInput(
                attrs={
                    'placeholder': 'Ingrese un nombre',
                }
            ),
            'cat': Select(
                attrs={
                    'class': 'select2',
                    'style': 'width: 100%'
                }
            ),
            
        }
        #excluir del form quien lo creo y modifico
        exclude = ['user_updated', 'user_creation']

    def save(self, commit=True):
        data = {}
        form = super()
        try:
            if form.is_valid():
                form.save()
            else:
                data['error'] = form.errors
        except Exception as e:
            data['error'] = str(e)
        return data
	    
	    


class TestForm(forms.Form):
    
    categories = forms.ModelChoiceField(queryset=Category.objects.all(), widget=forms.Select(attrs={
        'class': 'form-control select2',
        'style': 'width: 100%'
    }))

    products = forms.ModelChoiceField(queryset=Product.objects.none(), widget=forms.Select(attrs={
        'class': 'form-control select2',
        'style': 'width: 100%'
    }))

    # search = CharField(widget=TextInput(attrs={
    #     'class': 'form-control',
    #     'placeholder': 'Ingrese una descripción'
    # }))

    search = forms.ModelChoiceField(queryset=Product.objects.none(), widget=forms.Select(attrs={
        'class': 'form-control select2',
        'style': 'width: 100%'
    }))

    
class ClientForm(ModelForm):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.fields['names'].widget.attrs['autofocus'] = True

    class Meta:
        model = Client
        fields = '__all__'
        widgets = {
            'names': TextInput(
                attrs={
                    'placeholder': 'Ingrese sus nombres',
                }
            ),
            'surnames': TextInput(
                attrs={
                    'placeholder': 'Ingrese sus apellidos',
                }
            ),
            'phone': TextInput(
                attrs={
                    'placeholder': 'Ingrese su Telefono',
                }
            ),
            'address': TextInput(
                attrs={
                    'placeholder': 'Ingrese su dirección',
                }
            ),
            'detalles': TextInput(
                attrs={
                    'placeholder': 'Ingrese detalles',
                }
            ),
            'gender': Select()
        }
        exclude = ['user_updated', 'user_creation']

    def save(self, commit=True):
        data = {}
        form = super()
        try:
            if form.is_valid():
                instance = form.save()
                data = instance.toJSON()
            else:
                data['error'] = form.errors
        except Exception as e:
            data['error'] = str(e)
        return data

    # def clean(self):
    #     cleaned = super().clean()
    #     if len(cleaned['name']) <= 50:
    #         raise forms.ValidationError('Validacion xxx')
    #         # self.add_error('name', 'Le faltan caracteres')
    #     return cleaned
class MesaForm(ModelForm):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        #for form in self.visible_fields():
            #form.field.widget.attrs['class'] = 'form-control'
            #form.field.widget.attrs['autocomplete'] = 'off'
        self.fields['name'].widget.attrs['autofocus'] = True

    class Meta:
        model = Mesa
        fields = '__all__'
        widgets = {
            'name': TextInput(
                attrs={
                    'placeholder': 'Ingrese un nombre',
                }
            ), 
            'desc': Textarea(
                attrs={
                    'placeholder': 'Ingrese una descripción',
                    'rows': 3,
                    'cols': 3
                }
            ),
            
        }
        #excluir del form quien lo creo y modifico
        exclude = ['user_updated', 'user_creation']

    def save(self, commit=True):
        data={}
        form = super()
        try:
            if form.is_valid():
                form.save()
            else:
                data['error']=form.errors
        except Exception as e:
            data['error'] = str(e)
        return data



class SaleForm(ModelForm):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.fields['cli'].queryset = Client.objects.none()
        self.fields['tables'].queryset = Mesa.objects.all().filter(user_creation_id=get_current_user())

        #otra manera de agregar diseño
        for form in self.visible_fields():
            form.field.widget.attrs['class'] = 'form-control'
            form.field.widget.attrs['autocomplete'] = 'off'
        
    class Meta:
        model = Sale
        fields = '__all__'
        widgets = {
            'cli':Select(attrs={
                    'class': 'custom-select select2'
                    #'style': 'width: 100%'

                }
            ),
            'tables': Select(
                attrs={
                    'class': 'form-control select2',
                    'style': 'width: 100%'
                }
            ),
           
            'date_joined': DateInput(format='%Y-%m-%d',
                attrs={
                    'value': datetime.now().strftime('%Y-%m-%d'),
                    'autocomplete': 'off',
                    'class': 'form-control datetimepicker-input',
                    'id': 'date_joined',
                    'data-target': '#date_joined',
                    'data-toggle': 'datetimepicker'
                }
            ),
            'iva': TextInput(attrs={
                'class': 'form-control'
                }),

            'subtotal': TextInput(attrs={
                #que no se pueda editar y control clase de boo
                'readonly': True,
                'class': 'form-control'
                }
            ),
            'total': TextInput(attrs={
                #que no se pueda editar y control clase de boo
                'readonly': True,
                'class': 'form-control'
                }
            ),
            'pagorecibio': TextInput(attrs={
                #que no se pueda editar y control clase de boo
                'class': 'form-control'

                }
            ),
            'pagocambio': TextInput(attrs={
                #que no se pueda editar y control clase de boo
                'readonly': True,
                'class': 'form-control'

                }
            )
            
            
        }
        #excluir del form quien lo creo y modifico
        exclude = ['user_updated', 'user_creation']

   