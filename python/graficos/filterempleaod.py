class empleado:

	def __init__(self, nombre, cargo, salario):
		self.nombre=nombre
		self.cargo=cargo
		self.salario=salario
	def __str__(self):
		return"{} que trabaja como {} tiene u salario de {} $".format(self.nombre, self.cargo, self.salario)
 
listaempleado=[
empleado("genaro", "operador", 1500),
empleado("daniela", "encargada", 1700),
empleado("yessenia", "secretaria", 1000),	
empleado("mario", "lider", 1450)
]
salario_ALTOS=filter(lambda empleado:empleado.salario>1500,listaempleado)

for empleado_salario in salario_ALTOS:
	print(empleado_salario)
