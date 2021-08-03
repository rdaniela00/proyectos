import sqlite3

miconexion=sqlite3.connect("primeraBase")

micursor=miconexion.cursor()
#micursor.execute("CREATE TABLE PRODUCTOS (NOMBRE_ARTICULO VARCHAR(50), PRECIO INTEGER, SECCION VARCHAR(20))")
#micursor.execute("INSERT INTO PRODUCTOS VALUES('BALON', 15, 'DEPORTES')")
#variosProductos=[
	#("camiseta", 15, "DEPORTES"),
	#("JARRON", 20, "CERAMICA"),
	#("CAMION", 30, "JUGUETES")


#]

#miconexion.executemany("INSERT INTO PRODUCTOS VALUES(?,?,?)", variosProductos)


micursor.execute("SELECT * FROM PRODUCTOS")
variosProductos=micursor.fetchall()

for producto in variosProductos:
	print("nombre del producto:",producto[0], "secciion:", producto[2],"precio:", producto[1] )

miconexion.commit()
miconexion.close()