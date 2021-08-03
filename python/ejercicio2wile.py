#Crea un programa que pida números positivos indefinidamente. El programa termina cuando se introduce un número negativo.
# Finalmente el programa muestras la suma de todos los números introducidos
numero=int(input("ingresa un numero"))
suma=0

while numero>0:
	suma=suma+numero
	numero=int(input("itroduce otro numero"))

print("la suma de los numeros introduccios es" + str(suma))