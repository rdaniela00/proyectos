from configparser import ConfigParser

config = ConfigParser()
config.read('config.ini')


# obtenga una lista de todas las secciones
print('secciones: %s' % config.sections())