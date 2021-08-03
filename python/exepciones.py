class coche():
    def __init__(self):
        self.__largo = 250
        self.__ancho = 230
        self.__ruedas = 4
        self.__enmarcha = True

    def arrancar(self, arrancamos):
        self.__enmarcha = arrancamos
        if (self.__enmarcha):
            chequeo = self.chequeo_carro()

        if (self.__enmarcha and chequeo):
            return "el coche esta en marcha"
        elif(self.__enmarcha and chequeo == False):
            return"algo anda mal en el arranque"
        else:
            return "el coche esta alto"

    def estado(self):
        print("mi coche tiene", self.__ruedas, "ruedas. un ancho de:",
              self.__ancho, "y un largo de:", self.__largo)

    def chequeo_carro(self):
        print("realizar chequeo interno")
        self.gasolina = "ok"
        self.aceite = "mal"
        self.puertas = "cerradas"

        if (self.gasolina == "ok" and self.aceite == "ok" and self.puertas == "cerradas"):
            return True
        else:
            return False


miCoche = coche()


print(miCoche.arrancar(True))
miCoche.estado()

print("a continuacion creamos el segundo objeto---------------------")

miCoche2 = coche()

print(miCoche2.arrancar(False))
miCoche2.__ruedas = 23
miCoche2.estado()
