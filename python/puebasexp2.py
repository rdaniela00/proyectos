def divicion():
	try:
		op1=float(input("ingresa el numero"))
		op2=float(input("ingresa el numero"))

		
		print("el valor de la divicion es: " + str(op1/op2))
	except ValueError:
		print("El valor introducido es erroneo")
	except ZeroDivisionError:
		print("no se puede dividir por cero")
	print("calculo finalizado ")
	divicion()