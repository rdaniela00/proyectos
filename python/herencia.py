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


class furgoneta(vehiculos):
	def carga(self, cargar):
		self.cargado=cargar
		if (self.cargado):
			return "la furgoneta esta cargafa"
		else:
			return"la furgoneta n esta cargada"



class moto(vehiculos):
	hcaballito=""
	def caballito(self):
		self.hcaballito="voy haciendo caballito"
	def estado(self):
		print("marca:", self.marca, "\n modelo:", self.modelo, "\n en marcha:", self.enmarcha, "\n en aceleracion", self.acelera,"\n en freno:", self.frena, "\n", self.hcaballito)


class vElectricos():
	def __init__(self):
		self.autonimia=100
	def cargarenergia(self):
		self.cargando=True
		


class Vbicicleta(vehiculos,vElectricos):
	pass
mibici=Vbicicleta("marips", "hola")


mimoto=moto("italika", "CBR")
mimoto.caballito()
mimoto.estado()
mifurgoneta=furgoneta("chevi", "gissaaoa")
mifurgoneta.arrancar()
mifurgoneta.estado()
print(mifurgoneta.carga(True))