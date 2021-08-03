import configparser
config = configparser.ConfigParser()




"""def llamar():
	f = open("config.ini", "r")
	sections = config.sections()
	print(f'Sections: {sections}')
	for opcion in config['mysql']:
		print(opcion)
		
		
	if 'mysql' in config:
   		 print("La sección existe")
   		 

llamar()"""

def leerini(texto_buscar):

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




"""def fg():
	f = open("archivo.txt", "r")
	while(True):
    	 linea = f.readline()
     	 print(linea)
    	 if not linea:
        	 break
f.close()

leerini('user')"""