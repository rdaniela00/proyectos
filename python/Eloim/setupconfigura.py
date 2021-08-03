import configparser

configuracion = configparser.ConfigParser()
configuracion.read('C:\Users\danie\Desktop\respaldo\python\Eloim\config.ini')
seccionInstalacion = configuracion['INSTALACION']
directorio = seccionInstalacion['Directorio']
seccionMiscelaneo = configuracion['MISCELANEO']
licencia = seccionMiscelaneo['Licencia']

print('Este programa se instalará en', directorio, 'bajo la licencia', licencia)