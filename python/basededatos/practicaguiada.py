from tkinter import * #importamos la libreria tkinder
from tkinter import messagebox #importamos libreria messege box
import sqlite3 #importamos el gestor de BDD


#-------------------FUNCIONES------------------------------------------------
def conexionBDD():
	miconexion=sqlite3.connect("Usuarios")#creamos la conexion a la  base de datos
	micursor=miconexion.cursor()#se crea el cursor 

	try:
		micursor.execute('''
			CREATE TABLE DATOSUSUARIOS(
			ID INTEGER PRIMARY KEY AUTOINCREMENT,
			NOMBRE_USUARIO VARCHAR(50),
			PASSWORD VARCHAR(50),
			APELLIDO VARCHAR(10),
			DIRECCION VARCHAR(50),
			COMENTARIOS VARCHAR(100)) 
			''')
		messagebox.showinfo("BDD", "LA BDD ha sido creada")
	except:
		messagebox.showwarning("¡ALERTA!", "la BDD ya exite")
#funcion para salir de aplicacion
def salirApp():
	valor=messagebox.askquestion("Salir", "¿deseas salir del programa?")
	if valor=="yes":
		root.destroy()

def limpiarCampos():
	miID.set("")
	minombre.set("")
	mipass.set("")
	miapellido.set("")
	midireccion.set("")
	#PUNTO DE PARTIDA DE INICIO HASTA FINALE
	textoComentario.delete(1.0, END)

def crear():
	miconexion=sqlite3.connect("Usuarios")
	micursor=miconexion.cursor()
	#CONSULTA PARAMETRIZADA
	datos=minombre.get(), mipass.get(), miapellido.get(), midireccion.get(), textoComentario.get("1.0", END)

	#micursor.execute("INSERT INTO DATOSUSUARIOS VALUES(NULL, '"+ minombre.get()+"','"+mipass.get()+"', '"+miapellido.get()+"', '"+midireccion.get()+"', '"+textoComentario.get("1.0", END)+"')")
   #una cvez que se tien la consulta se le pone el comit para que ejecute la instruccion
	micursor.execute("INSERT INTO DATOSUSUARIOS VALUES(NULL,?,?,?,?,?)",(datos))

	miconexion.commit()

	messagebox.showinfo("BDD", "registro insertado")
def leer():
	miconexion=sqlite3.connect("Usuarios")
	micursor=miconexion.cursor()

	micursor.execute("SELECT * FROM DATOSUSUARIOS WHERE ID=" + miID.get())
	#el fechall es todo los registros que cumplan con la consulta nos devuelve un array
	elusuario=micursor.fetchall()
    #el sig es recorrer el array
	for usuario in elusuario:
    	 miID.set(usuario[0])					
    	 minombre.set(usuario[1])
    	 mipass.set(usuario[2])
    	 miapellido.set(usuario[3])
    	 midireccion.set(usuario[4])
    	 textoComentario.insert(1.0, usuario[5])
	miconexion.commit()

def actualizar():
	miconexion=sqlite3.connect("Usuarios")
	micursor=miconexion.cursor()

	micursor.execute("UPDATE DATOSUSUARIOS SET NOMBRE_USUARIO='"+minombre.get()+"', PASSWORD ='"+mipass.get()+"', APELLIDO='"+miapellido.get()+"', DIRECCION='"+midireccion.get()+"', COMENTARIOS='"+textoComentario.get("1.0", END)+"' WHERE ID="+miID.get())
   #una cvez que se tien la consulta se le pone el comit para que ejecute la instruccion
	miconexion.commit()

	messagebox.showinfo("BDD", "registro se a actualizado con exito")

def eliminar():
	miconexion=sqlite3.connect("Usuarios")
	micursor=miconexion.cursor()

	micursor.execute("DELETE FROM DATOSUSUARIOS WHERE ID="+ miID.get())

	miconexion.commit()

	messagebox.showinfo("BDD", "se ha eliminado el registro")





root=Tk()#creamos el tk
root.title("Practica Guiada")


barramenu=Menu(root)#creamos un menu que estara en el root
root.config(menu=barramenu, width=300, height=300)

bdd=Menu(barramenu, tearoff=0)#se agrega el campo a la barrra menu y se pone en tear para qeu no se muestre lineas arriba
bdd.add_command(label="Conectar", command=conexionBDD)#se agrrega esta funcion para agregar campos hacia abajo
bdd.add_command(label="Salir", command=salirApp)

borrarMenu=Menu(barramenu, tearoff=0)
borrarMenu.add_command(label="Borrar Campos", command=limpiarCampos)

CRUD=Menu(barramenu, tearoff=0)
CRUD.add_command(label="Crear", command=crear)
CRUD.add_command(label="Leer", command=leer)
CRUD.add_command(label="Actualizar", command=actualizar)
CRUD.add_command(label="Borrar", command=eliminar)

ayudaMenu=Menu(barramenu, tearoff=0)
ayudaMenu.add_command(label="Acerda de..")
ayudaMenu.add_command(label="Licencia")

barramenu.add_cascade(label="BDD", menu=bdd)#agrega los elementos a la barra de menu
barramenu.add_cascade(label="Borrar", menu=borrarMenu)
barramenu.add_cascade(label="CRUD", menu=CRUD)
barramenu.add_cascade(label="Ayuda", menu=ayudaMenu)

#------------comienzo de campos--------------------------------------------------
#los botones textos y entry se aran dentro de un frame
miFrame=Frame(root)#se crea el frame que esta dentro del root
miFrame.pack()#empaquetamos en frame pa que aparezca en el root

#VARIABLES para poder manipular el CRUD
miID=StringVar()
minombre=StringVar()
mipass=StringVar()
miapellido=StringVar()
midireccion=StringVar()
#asignamos a cada uno de los entry la variable stringvar correspondientes
cuadroId=Entry(miFrame, textvariable=miID)#creamos el entry dentro de muframe
cuadroId.grid(row=0, column=1, padx=10, pady=10)#expecificamos donde esta dentro del grid

cuadroNombre=Entry(miFrame, textvariable=minombre)
cuadroNombre.grid(row=1, column=1, padx=10, pady=10)
cuadroNombre.config(fg="red", justify="right")#para darle config al entry diseño tambien y eso

cuadroPass=Entry(miFrame, textvariable=mipass)
cuadroPass.grid(row=2, column=1, padx=10, pady=10)
cuadroPass.config(show="*")

cuadroApellido=Entry(miFrame, textvariable=miapellido)
cuadroApellido.grid(row=3, column=1, padx=10, pady=10)

cuadroDireccion=Entry(miFrame, textvariable=midireccion)
cuadroDireccion.grid(row=4, column=1, padx=10, pady=10)

#creamos el caampo texto
textoComentario=Text(miFrame, width=16, height=5)#agregamos el text dentro del frame
textoComentario.grid(row=5, column=1, padx=10, pady=10)
#creamos la barra de desplazamientos 
scrollVert=Scrollbar(miFrame, command=textoComentario.yview)#el scroll pertenece a mifrmae y yview es para que lo muestre en frma vertical el texto
scrollVert.grid(row=5, column=2, sticky="nsew")
#le decimos al texto comentario que debe de tener esta barra desplazable
textoComentario.config(yscrollcommand=scrollVert.set)


#-----------------aqui comienzan los label--------------------------------
IDlabel=Label(miFrame, text="ID")
IDlabel.grid(row=0, column=0, sticky="e", padx=10, pady=10)

nomlabel=Label(miFrame, text="Nombre:")
nomlabel.grid(row=1, column=0, sticky="e", padx=10, pady=10)

passlabel=Label(miFrame, text="Password:")
passlabel.grid(row=2, column=0, sticky="e", padx=10, pady=10)

apelabel=Label(miFrame, text="Apellido")
apelabel.grid(row=3, column=0, sticky="e", padx=10, pady=10)

dirlabel=Label(miFrame, text="Direccion")
dirlabel.grid(row=4, column=0, sticky="e", padx=10, pady=10)

comentariolbl=Label(miFrame, text="Comentarios")
comentariolbl.grid(row=5, column=0, sticky="e", padx=10, pady=10)


#-------------aqui van los botones--------------------------------------
miFrame2=Frame(root)
miFrame2.pack()

botonCrear=Button(miFrame2, text="Crear", command=crear)
botonCrear.grid(row=1, column=0, sticky="e", padx=10, pady=10)

botonLeer=Button(miFrame2, text="Leer", command=leer)
botonLeer.grid(row=1, column=1, sticky="e", padx=10, pady=10)

botonActualizar=Button(miFrame2, text="Actualizar", command=actualizar)
botonActualizar.grid(row=1, column=2, sticky="e", padx=10, pady=10)

botonBorrar=Button(miFrame2, text="Borrar", command=eliminar)
botonBorrar.grid(row=1, column=3, sticky="e", padx=10, pady=10)













root.mainloop()#esta clase tiene que ir siempre es pa que se muestre
