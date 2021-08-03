def funcion_decoradora(funcion_parametro):

	def funcion_intermedia(*args,**kwargs):
		#acciones adicionales que decoran 
		print("vamos a realizar un calculo: ")
		funcion_parametro(*args, **kwargs)

		#acciones adiccionales que decoran
		print("hemos terminado el calculo")
	return funcion_intermedia



#arg resive muchos parametros



@funcion_decoradora
def suma(num1,num3,num2):
	print(num1+num3+num2)
@funcion_decoradora
def resta(num1,num3):
	print(num1-num3)
def potenica(base, exponete):

	print(pow(base, exponete))

suma(7,9,2)
resta(9,7)
#potenica(5,3)
#viajan con clave valor por eso el uso kwargs
potenica(base=5,exponete=3)
	