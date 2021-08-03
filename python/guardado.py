import pickle

class persona():
	def __init__(self, nombre, genero, edad):
		self.nombre=nombre
		self.genero=genero
		self.edad=edad
		print("se a crado una persona nueva con el nombre de: ", self.nombre)

	def __str__(self):
		return "{} {} {}".format(self.nombre, self.genero, self.edad)



class listapersonasa():
	personas=[]

	def __init__(self):
		milistaDePersonas=open("ficheroexterno", "ab+")
		milistaDePersonas.seek(0)

		try:
			self.personas=pickle.load(milistaDePersonas)
			print("se cargaron {} personas".format(len(self.personas)))
		except:
			print("el fichero esta vacio")
		finally:
			milistaDePersonas.close()
			del(milistaDePersonas)

	def agregarpersonas(self, p):
		self.personas.append(p)
		self.guardarPersonasFicherExterno()

	def mostarpersonas(self):
		for p in self.personas:
			print(p)

	def guardarPersonasFicherExterno(self):
		milistaDePersonas=open("ficheroexterno", "wb")
		pickle.dump(self.personas, milistaDePersonas)
		milistaDePersonas.close()
		del(milistaDePersonas)
	def mostrarinfoficheroexterno(self):
		print("la informacion del fichero externo es la siguiente")
		for p in self.personas:
			print(p)



milista=listapersonasa()
p=persona("ximena", "femenino", 12)
milista.agregarpersonas(persona)
milista.mostrarinfoficheroexterno()



