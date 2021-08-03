from funciones import leerini,isUserAdmin
import pyodbc
import pymysql


#leer ini
DRIVER=leerini('drivers')
varhos=leerini('host')
puertor=leerini('port')
usuario=leerini('user')
passwd=leerini('password')
dased=leerini('db')




if len(DRIVER)==1 or len(varhos)==1 or len(puertor)==1 or len(usuario)==1 or len(passwd)==1 or len(dased)==1:
  print("Está vacía")
else:
  print("NO Está vacía")

#validacion como administraodr
asm=isUserAdmin()
if asm == 0:
  print("debe iniciar como administrador")



import mysql.connector
from mysql.connector import errorcode

try:
  cnx = mysql.connector.connect(host='localhost',
                             user='root',
                             port='3306',
                             password='12345',
                             db='pvental')
except mysql.connector.Error as err:
  if err.errno == errorcode.ER_ACCESS_DENIED_ERROR:
    print("contraseña o usuario incorrectos")
  elif err.errno == errorcode.ER_BAD_DB_ERROR:
    print("la Base de Datos no existe")
    import creacionBd.py
  else:
    print(err)
else:
  cnx.close()















        
   
