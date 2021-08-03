	#Crea un programa que pida dos números por teclado. 
#El programa tendrá una función llamada “DevuelveMax” encargada de devolver el número más alto de los dos introducidos. 

num1=(int(input("ingresa numero uno")))
num2=(int(input("ingresa numero dos")))

def devuelvemax(n1, n2):
	if n1<n2:
		print(n2)
	elif n2<n1:
		print("n1")
	else:
		print("son iguales")


devuelvemax(num1, num2)
