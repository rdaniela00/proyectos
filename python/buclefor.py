print("asignaturas de ingenieria en sistemas")
print("asignaturas optativas: -inteligenciaa artificial -calculo -avnazados algoritmos")

opcion=input("escribe la asignatura")

asignatura=opcion.lower()

if asignatura in("in inteligenciaa artificial", "calculo", "avnazados algoritmos"):
	print("asigmatura elegida" + asignatura)