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



ficheroapertura=open("coche", "rb")
coche=pickle.load(ficheroapertura)
ficheroapertura.close()
for c in coche:
	print(c.estado())