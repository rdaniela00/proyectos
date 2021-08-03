import configparser
config = configparser.ConfigParser()


def leerini():

	f = open("config.ini", "r")
	while(True):
    	 linea = f.read()
    	 print(linea)
    	 if ("" == linea):
    	 	break 
	f.close()

leerini()