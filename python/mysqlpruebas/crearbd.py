import pymysql

connection = pymysql.connect(
host='localhost', # o localhost si tu levantaste el servidor
port = 3306,
user='root',
password='12345'
)
try:

	with connection.cursor() as cursor:
		sql = 'CREATE DATABASE  pventa'
		cursor.execute(sql)
		print("creada")
	connection.commit()
except:
	connection.rollback()
finally:
	connection.close()

