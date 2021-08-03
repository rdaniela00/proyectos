import pickle


class vehiculos():
	def __init__(self, marca, modelo):
		self.marca=marca
		self.modelo=modelo
		self.enmarcha=False
		self.acelera=False
		self.frena=False

	def arrancar(self):
		self.enmarcha=True
	def acelearar(self):
		self.acelera=True
	def detener(self):
		self.frena=True

	def estado(self):
		print("marca:", self.marca, "\n modelo:", self.modelo, "\n en marcha:", self.enmarcha, "\n en aceleracion", self.acelera,"\n en freno:", self.frena)

coche1=vehiculos("mazda", "hola")

coche2=vehiculos("chevy", "adios")

coche3=vehiculos("sentra", "2017")

coche=[coche1, coche2, coche3]

fichero=open("coche", "wb")
pickle.dump(coche, fichero)
fichero.close()
del(fichero)

