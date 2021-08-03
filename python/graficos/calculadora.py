from tkinter import * 

raiz=Tk()#Creamos la raiz del proyecto

miframe=Frame(raiz)#Creamos el frame
miframe.pack()#Empaquetamos el frame
operacion=""#creamos variable general para alamcenar valor de operacion
resultado=0#variable res para saber el valor de las operaciones


#------------pantalla------------------------------------------------------------
numeropantallas=StringVar()#creamos variable tipo string

pantalla=Entry(miframe, textvariable=numeropantallas)
pantalla.grid(row=1, column=1, padx=10, pady=10, columnspan=4)#Asignamos un layout de tipo grid
pantalla.config(background="black", fg="#03f943", justify="right")#Establecemos las propiedades de la pantalla



#-------------pulsaciones teclado-------------------------------------
def numeropulsado(num):

	global operacion

	if operacion!="":
		numeropantallas.set(num)

		operacion=""
	else:

		numeropantallas.set(numeropantallas.get()+ num)#concatena lo que tiene en pantallas mas 4



#------------funcion suma----------------------------------------------
def suma(num):
	global operacion
	global resultado
	resultado+=int(num)
	operacion="suma"
	numeropantallas.set(resultado)

#-------------------funcion el_resultado------------------------------------------------
def el_resultado():
	global resultado
	numeropantallas.set(resultado+int(numeropantallas.get()))
	resultado=0



#------------botones fila 1-------------------------------------------------------------
boton7=Button(miframe, text="7", width=3, command=lambda:numeropulsado("7"))
boton7.grid(row=2, column=1)
boton8=Button(miframe, text="8", width=3, command=lambda:numeropulsado("8"))
boton8.grid(row=2, column=2)
boton9=Button(miframe, text="9", width=3, command=lambda:numeropulsado("9"))
boton9.grid(row=2, column=3)
botondividir=Button(miframe, text="/", width=3)
botondividir.grid(row=2, column=4)



#------------botones fila 2-------------------------------------------------------------
boton4=Button(miframe, text="4", width=3, command=lambda:numeropulsado("4"))
boton4.grid(row=3, column=1)
boton5=Button(miframe, text="5", width=3, command=lambda:numeropulsado("5"))
boton5.grid(row=3, column=2)
boton6=Button(miframe, text="6", width=3, command=lambda:numeropulsado("6"))
boton6.grid(row=3, column=3)
botonMult=Button(miframe, text="x", width=3)
botonMult.grid(row=3, column=4)


#------------botones fila 3-------------------------------------------------------------
boton1=Button(miframe, text="1", width=3, command=lambda:numeropulsado("1"))
boton1.grid(row=4, column=1)
boton2=Button(miframe, text="2", width=3, command=lambda:numeropulsado("2"))
boton2.grid(row=4, column=2)
boton3=Button(miframe, text="3", width=3, command=lambda:numeropulsado("3"))
boton3.grid(row=4, column=3)
botonMenos=Button(miframe, text="-", width=3)
botonMenos.grid(row=4, column=4)



#------------botones fila 4-------------------------------------------------------------
boton0=Button(miframe, text="0", width=3, command=lambda:numeropulsado("0"))
boton0.grid(row=5, column=1)
botoncoma=Button(miframe, text=",", width=3, command=lambda:numeropulsado(","))
botoncoma.grid(row=5, column=2)
botonsuma=Button(miframe, text="+", width=3, command=lambda:suma(numeropantallas.get()))
botonsuma.grid(row=5, column=3)
botonigual=Button(miframe, text="=", width=3, command=lambda:el_resultado())
botonigual.grid(row=5, column=4)




raiz.mainloop()#ciclo infinito de ejecucion de frame