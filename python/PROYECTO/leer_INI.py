from configparser import ConfigParser

config = ConfigParser()
config.read('config.ini')



# obtenga una lista de todas las secciones
print('secciones: %s' % config.sections())

# Puede tratarlo como iterable y verificar las claves o recorrerlas
if 'main_section' in config:
    print('La sección principal existe en la configuración.')

for section in config:
    print('secciones: %s' % section)
    """for key, value in config[section].items():
        print('Key: %s, Value: %s' % (key, value))"""

# Si sabe exactamente qué clave está buscando, 
#intente obtenerla directamente, opcionalmente proporcionando un valor predeterminado
"""print(config['main_section'].get('key1'))  # Obtiene como cadena
print(config['main_section'].getint('key2',))
print(config['main_section'].getfloat('key3'))
print(config['main_section'].getboolean('key99', False))"""