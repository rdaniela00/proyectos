import configparser
import sys, os, traceback, types


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

def isUserAdmin():
    if os.name == 'nt':
        import ctypes
        ad=ctypes.windll.shell32.IsUserAnAdmin()
        if ad == 0:
            print("debe iniciar como administrador")
            return ad

    else:
        raise RuntimeError("sistema opertivo no compatible: %s" % (os.name))

