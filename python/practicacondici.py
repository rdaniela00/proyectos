print("programa de becas 2020")

distracia_escuela=int(input("ingresa la distrancia en kilometros"))
print(distracia_escuela)

numero_hermanios=int(input("cuantos hermanos estudian"))
print(numero_hermanios)

salario=int(input("ingresa salario anual"))
print(salario)

if distracia_escuela>40 and numero_hermanios>2 and salario<=20000:
	print("tienes derecho a beca")
else:
	print("no tienes derecho a beca")