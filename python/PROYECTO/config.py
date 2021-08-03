import configparser

config = configparser.ConfigParser()
config.read('configuracionn.ini')

database_name = config['DEFAULT']['DB_NAME']
