import configparser
config = configparser.ConfigParser()
config.read('config.ini')
sections = config.sections()
print(f'Sections: {sections}')



def llamar():
	for opcion in config['mysql']:
		print(opcion) 
	if 'mysql' in config:
   		 print("La sección existe")

llamar()