import configparser


def leerini(texto_buscar):
    f = configparser.ConfigParser()

    f = open("config.ini", "r")
    
    for linea_texto in f:
         
         if ("" == linea_texto):
            return ''
         valor=linea_texto.find(texto_buscar)
         if valor ==0:
             a=linea_texto.find("=")
             o = linea_texto[a+1: 50]
             print(o)
             return o
         
    f.close()
