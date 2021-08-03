import os
from configparser import ConfigParser


config = ConfigParser()
config_path = os.path.join(os.path.dirname(os.path.abspath(__file__)), 'config.ini')
#print('secciones: %s' % config.sections())

def servidor(localhost,db_name,db_usuario):
	if sections == localhost:
		print("esta configurado")
	else:
		print("no esta configurado")

def main_section(key1, key2, key3):
	gloal=""

if not os.path.isfile(config_path):
    raise BadConfigError # not a standard python exception

config.read(config_path)

main_section = config.get('main', 'test_key') # value


	

servidor()




"""	return(localhost, db_name,db_usuario)
def servidor(localhost):
	valoracion="activado"
	if calificaacion<5:
			valoracion="suspenso"
	return valoracion"""