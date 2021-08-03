#Crea un programa que pida por teclado introducir una contraseña. 
#La contraseña no podrá tener menos de 8 caracteres ni espacios en blanco. Si la contraseña es correcta, 
#el programa imprime “Contraseña OK”. En caso contrario imprime “Contraseña errónea” 

micontraseña=input(" escribe la contraseña")
contador=0

for i in range(len(micontraseña)):
	if micontraseña[i]==" ":
		contador=1
if len(micontraseña)<8 or contador>0:
	print("la contraseña no es correcta")
else:
	print("la contraseña es correcta")