import sqlite3#agregadmos sqllite

#creamos la conexio 
miconexion=sqlite3.connect("Gestionarproductos")

#creamos el cursor
micursor=miconexion.cursor()
#consulta con estos apostrofes su funcio es pa consultas largas poder brincar renclon
micursor.execute('''
    CREATE TABLE PRODUCTOS(
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    NOMBRE_ARTICULO VARCHAR(50),
    PRECIO INTEGER,
    SECCION VARCHAR(20))  
''')

productos=[
    ("pelota", 20, "jugeteria"),
    ("pantalón", 15, "confección"),
    ("destornillador", 25, "ferretería"),
    ("jarrón", 45, "cerámica")
]

micursor.executemany("INSERT INTO PRODUCTOS VALUES(NULL, ?, ?, ?)", productos)
#para verificar ccada cambio 
miconexion.commit()

#cerramos la conexion
miconexion.close()
