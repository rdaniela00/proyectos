from django import forms
from core.user.models import User

class RestablecerpasswordForm(forms.Form):
    username = forms.CharField(widget=forms.TextInput(attrs={
        'placeholder': 'Ingrese su usuario',
        'class': 'form-control',
        'autocomplete': 'off'
    }))

    def clean(self):
        cleaned = super().clean()
        if not User.objects.filter(username=cleaned['username']).exists():
            self._errors['error'] = self._errors.get('error', self.error_class())
            self._errors['error'].append('El usuario no existe')
        return cleaned

    def get_user(self):
    	#capturando cual es el valor que llega de user
    	username = self.cleaned_data.get('username')
    	return User.objects.get(username=username)


class CambiopasswordForm(forms.Form):
    password = forms.CharField(widget=forms.PasswordInput(attrs={
        'placeholder': 'Ingrese una nueva Contraseña',
        'class': 'form-control',
        'autocomplete': 'off'
    }))
    confirmPassword = forms.CharField(widget=forms.PasswordInput(attrs={
        'placeholder': 'Confirmar la nueva Contraseña',
        'class': 'form-control',
        'autocomplete': 'off'
    }))
    def clean(self):
        cleaned = super().clean()
        password = cleaned['password']
        confirmPassword = cleaned['confirmPassword']
        if password != confirmPassword:
            self._errors['error'] = self._errors.get('error', self.error_class())
            self._errors['error'].append('Las contraseñas deberian ser iguales')
        return cleaned

    

