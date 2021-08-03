from tkinter import * #importamos la libreria tkinder
from tkinter import messagebox #importamos libreria messege box
from funciones import leerini,isUserAdmin
import pymysql
import mysql.connector
import MySQLdb
import configparser
import MySQLdb.cursors





#leer ini


#-------------------FUNCIONES------------------------------------------------
def conexionBDD():
	try:
		config = configparser.ConfigParser()
		config.read('config.ini')
		
		miconexion=mysql.connector.connect(host = config['mysql']['host'],
                             	user = config['mysql']['user'],
                             	port= config['mysql']['port'],
                             	passwd = config['mysql']['password']
                            	 )#creamos la conexion a la  base de datos
		cur = miconexion.cursor()
		sql=  'CREATE DATABASE pventa' 
		cur.execute(sql)

		try:
			
			miconexion=mysql.connector.connect(host = config['mysql']['host'],
                             	user = config['mysql']['user'],
                             	port= config['mysql']['port'],
                             	passwd = config['mysql']['password'],
                             	db= config['mysql']['db']
                            	 )#creamos la conexion a la  base de datos
			cur = miconexion.cursor()




			cur.execute('''CREATE TABLE empresas (id_empresa int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
			 clave varchar(2) NOT NULL DEFAULT  '' ,
			 nombre varchar(90) NOT NULL DEFAULT '',
			 rfc varchar(15) NOT NULL DEFAULT '',
		     curp varchar(50) NOT NULL DEFAULT '',
  		     email varchar(50) NOT NULL DEFAULT '',  		  
  		     direccion varchar(40) NOT NULL DEFAULT '',  		  
  		     numero_ext varchar(7) NOT NULL DEFAULT '',  		  
  		     numero_int varchar(7) NOT NULL DEFAULT '',  		  
    		 municipio varchar(50) NOT NULL DEFAULT '',  		  
    		 colonia varchar(50) NOT NULL DEFAULT '',  		  
    		 estado varchar(40) NOT NULL DEFAULT '',  		  
    		 cp varchar(7) NOT NULL DEFAULT '',  		  
    		 pais varchar(50) NOT NULL DEFAULT '',  		  
    		 localidad varchar(50) NOT NULL DEFAULT '',  		  
    		 telefono varchar(50) NOT NULL DEFAULT '',  		  
    		 referencia varchar(50) NOT NULL DEFAULT '',  		  
    		 representa varchar(50) NOT NULL DEFAULT '',  		  
    		 lugar_exp varchar(90) NOT NULL DEFAULT '',  		  
    		 calle_exp varchar(50) NOT NULL DEFAULT '',  		  
    		 numext_exp varchar(7) NOT NULL DEFAULT '',  		  
    		 numint_exp varchar(7) NOT NULL DEFAULT '',  		  
    		 colonia_exp varchar(50) NOT NULL DEFAULT '',  		 
    		 localidad_exp varchar(50) NOT NULL DEFAULT '',  		  
    		 referen_exp varchar(50) NOT NULL DEFAULT '',  		  
    		 municipio_exp varchar(40) NOT NULL DEFAULT '',  		  
    		 estado_exp varchar(40) NOT NULL DEFAULT '',  		  
    		 pais_exp varchar(40) NOT NULL DEFAULT '',  		  
    		 cp_exp varchar(7) NOT NULL DEFAULT '',  		  
		     folio tinyint(7) NOT NULL DEFAULT '0',
		     folent tinyint(7) NOT NULL DEFAULT '0',
		     folcom tinyint(7) NOT NULL DEFAULT '0',
		     folaju tinyint(7) NOT NULL DEFAULT '0',
  		     folcot tinyint(7) NOT NULL DEFAULT '0',
		     folfac tinyint(7) NOT NULL DEFAULT '0',
		     folbas tinyint(7) NOT NULL DEFAULT '0',
		     folrem tinyint(7) NOT NULL DEFAULT '0',
		     folpre tinyint(7) NOT NULL DEFAULT '0',
		     folser tinyint(7) NOT NULL DEFAULT '0',
		     folrec tinyint(7) NOT NULL DEFAULT '0',
		     folsep tinyint(7) NOT NULL DEFAULT '0',
		     dolar decimal(12,2) NOT NULL DEFAULT '0',
		     pedido tinyint(7) NOT NULL DEFAULT '0',
		     tarserv decimal(12,2) NOT NULL DEFAULT '0',
		     tarrevisa decimal(12,2) NOT NULL DEFAULT '0',
		     plazo tinyint(5) NOT NULL DEFAULT '0',
    	     ruta1 varchar(50) NOT NULL DEFAULT '',  		  
    	     ruta2 varchar(50) NOT NULL DEFAULT '',  		  
    	     porpre1 tinyint(3) NOT NULL DEFAULT '0',
   		     porpre2 tinyint(3) NOT NULL DEFAULT '0',
   		     porpre3 tinyint(3) NOT NULL DEFAULT '0',
   		     porpre4 tinyint(3) NOT NULL DEFAULT '0',
   		     porpre5 tinyint(3) NOT NULL DEFAULT '0',
   		     rutaarch_cer varchar(100) NOT NULL DEFAULT '',  		  
   		     rutaarch_key varchar(100) NOT NULL DEFAULT '',  		  
   		     rfccertifica varchar(100) NOT NULL DEFAULT '',  		  
   		     numseriecert varchar(40) NOT NULL DEFAULT '',  		  
   		     certificado text NOT NULL,  		  
    	     validodesde varchar(30) NOT NULL DEFAULT '',  		  
   		     hasta varchar(30) NOT NULL DEFAULT '',  		  
   		     contraseña varchar(15) NOT NULL DEFAULT '',  		  
   		     campo2 varchar(15) NOT NULL DEFAULT '',  		  
   		     rutadelxml varchar(100) NOT NULL DEFAULT '',  		  
   		     cveregimen varchar(3) NOT NULL DEFAULT '',  		  
   		     regimen varchar(100) NOT NULL DEFAULT '',  		  
   		     mailfrom varchar(100) NOT NULL DEFAULT '',  		  
   		     mailserver varchar(50) NOT NULL DEFAULT '',  		  
   		     mailuser varchar(50) NOT NULL DEFAULT '',  		  
   		     mailpass varchar(50) NOT NULL DEFAULT '',  		  
   		     foliofiscal varchar(50) NOT NULL DEFAULT '',  		  
   		     certifisat varchar(40) NOT NULL DEFAULT '',  		  
   		     fechacert varchar(40) NOT NULL DEFAULT '',  		  
   		     utilidad1 tinyint(4) NOT NULL DEFAULT '0',
   		     utilidad2 tinyint(4) NOT NULL DEFAULT '0',
   		     utilidad3 tinyint(4) NOT NULL DEFAULT '0',
   		     utilidad4 tinyint(4) NOT NULL DEFAULT '0',
   		     utilidad5 tinyint(4) NOT NULL DEFAULT '0',
   		     marcap1v tinyint(1) NOT NULL DEFAULT '0',
   		     marcap2v tinyint(1) NOT NULL DEFAULT '0',
   		     marcap3v tinyint(1) NOT NULL DEFAULT '0',
   		     marcap4v tinyint(1) NOT NULL DEFAULT '0',
   		     marcap5v tinyint(1) NOT NULL DEFAULT '0',
   		     porpre1vta tinyint(4) NOT NULL DEFAULT '0',
   		     porpre2vta tinyint(4) NOT NULL DEFAULT '0',
   		     porpre3vta tinyint(4) NOT NULL DEFAULT '0',
   		     porpre4vta tinyint(4) NOT NULL DEFAULT '0',
   		     porpre5vta tinyint(4) NOT NULL DEFAULT '0',
   		     serviciomen tinyint(2) NOT NULL DEFAULT '0',
   		     cerfinkok varchar(100) NOT NULL DEFAULT '',  		  
   		     keyfinkok varchar(100) NOT NULL DEFAULT '',  		  
     	     ruta_logo varchar(100) NOT NULL DEFAULT '',  		  
   		     cta_finkok varchar(60) NOT NULL DEFAULT '',  		  
   		    pas_finkok varchar(30) NOT NULL DEFAULT ''
			);

			CREATE TABLE pventa.usuario ( 
    	id_usuario integer AUTO_INCREMENT PRIMARY KEY,
    	nombre varchar(20) NOT NULL,
   		password int(12) NOT NULL
      ); 
      INSERT INTO  usuario (nombre, password)VALUES('guadalajara', 1234);
      ''')
  
      
      
			miconexion.commit()
		finally:
			miconexion.close()
			messagebox.showinfo("BDD", "LA BDD ha sido creada")
	except:
		 messagebox.showwarning("¡ALERTA!", "la BDD ya exite")

    

#funcion para salir de aplicacion
def salirApp():
	valor=messagebox.askquestion("Salir", "¿deseas salir del programa?")
	if valor=="yes":
		formulario.destroy()




formulario=Tk()#creamos el tk
formulario.title("conexion con BDD")
formulario.iconbitmap(r'C:\Users\danie\Desktop\respaldo\python\Eloim\empresa.ico')
formulario.geometry("550x300")
imagen=PhotoImage(file="unnamed.png")
fondo=Label(formulario, image=imagen).place(x=0, y=0, width=180, height=250)




#------------comienzo de campos--------------------------------------------------
#los botones textos y entry se aran dentro de un frame
miFrame=Frame(formulario)#se crea el frame que esta dentro del root
miFrame.pack()#empaquetamos en frame pa que aparezca en el root

#VARIABLES para poder manipular el CRUD
miID=StringVar()
minombre=StringVar()
mipass=StringVar()
miapellido=StringVar()
midireccion=StringVar()
#asignamos a cada uno de los entry la variable stringvar correspondientes
cuadroserver=Entry(miFrame, textvariable=miID)#creamos el entry dentro de muframe
cuadroserver.insert(0, "localhost")
cuadroserver.grid(row=0, column=1, padx=10, pady=10)#expecificamos donde esta dentro del grid

cuadroNombre=Entry(miFrame,)
cuadroNombre.insert(0, "root")
cuadroNombre.grid(row=1, column=1, padx=10, pady=10)
#para darle config al entry diseño tambien y eso

cuadroPuerto=Entry(miFrame, textvariable=mipass)
cuadroPuerto.insert(0, "3306")
cuadroPuerto.grid(row=2, column=1, padx=10, pady=10)


cuadroPass=Entry(miFrame, textvariable=miapellido)
cuadroPass.insert(0, "pass")
cuadroPass.grid(row=3, column=1, padx=10, pady=10)
cuadroPass.config(show="*")

cuadroDatos=Entry(miFrame, textvariable=midireccion)
cuadroDatos.insert(0, "pventa")
cuadroDatos.grid(row=4, column=1, padx=10, pady=10)




#-----------------aqui comienzan los label--------------------------------
servidor=Label(miFrame, text="Servidor")
servidor.grid(row=0, column=0, sticky="e", padx=10, pady=10)

usuario=Label(miFrame, text="Usuario:")
usuario.grid(row=1, column=0, sticky="e", padx=10, pady=10)

puerto=Label(miFrame, text="Puerto:")
puerto.grid(row=2, column=0, sticky="e", padx=10, pady=10)

PASSE=Label(miFrame, text="Password:")
PASSE.grid(row=3, column=0, sticky="e", padx=10, pady=10)

based=Label(miFrame, text="Base Datos:")
based.grid(row=4, column=0, sticky="e", padx=10, pady=10)




#-------------aqui van los botones--------------------------------------
miFrame2=Frame(formulario)
miFrame2.pack()

botonCrear=Button(miFrame2, text="Conectar", command=conexionBDD)
botonCrear.grid(row=1, column=0, sticky="e", padx=10, pady=10)


btncancelar=Button(miFrame2, text="cancelar", command=salirApp)
btncancelar.grid(row=1, column=3, sticky="e", padx=10, pady=10)


formulario.mainloop()#esta clase tiene que ir siempre es pa que se muestre


