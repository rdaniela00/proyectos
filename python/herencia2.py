class persona():
	def __init__(self, nombre, edad, lugar_residencia):
		self.nombre=nombre
		self.edad=edad
		self.lugar_residencia=lugar_residencia
	def descripcion(self):
		print("nombre: ", self.nombre, "edad: ", self.edad, "lugar donde vive: ", self.lugar_residencia)


class empleado(persona):
	def __init__(self, salario, antiguedad, nombre_empleado, edad_empleado, residencia):
		super().__init__(nombre_empleado, edad_empleado,residencia)
		self.salario=salario
		self.antiguedad=antiguedad

antonio=persona(1500, 4, "manuela", 18, "cancun")
antonio.descripcion()