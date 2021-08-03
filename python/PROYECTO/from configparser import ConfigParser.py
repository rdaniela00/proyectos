from configparser import ConfigParser

config = ConfigParser()
config['main_section'] = {
    'key1': 'daniela',
    'key2': 123,
    'key3': 123.45,
}
config['PRODUCTION'] = {
	'DB_NAME' : 'USUARIOS',
	'DB_USER' : 'JIMENA',
	'DB_PASSWORD' : 1234
}
"""config['DEFAULT'] = {'ServerAliveInterval': '45',
	                     'Compression': 'yes',
	                      'CompressionLevel': '9'
}"""

config['Red']
; Poner UsarProxy=1 si no hay cortafuegos
UsarProxy=1
Proxy=192.168.0.1

[Preferencias]
PaginaInicio=https://wikipedia.org
Maximizar=1

with open('config.ini', 'w') as output_file:
    config.write(output_file)

