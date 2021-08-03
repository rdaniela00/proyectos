print("programa de evaluacion de notas")

nota_almno=input()


def examen(calificaacion):
	valoracion="aprobado"
	if calificaacion<5:
			valoracion="suspenso"
	return valoracion
print(examen(int(nota_almno)))	
