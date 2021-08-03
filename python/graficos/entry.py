from tkinter import *

bott=Tk()

miframe=Frame(bott, width=1200, height=600)
miframe.pack()

minombress=StringVar()
apellidos=StringVar()
segapellido=StringVar()



cuadronombre=Entry(miframe, textvariable=minombress)
cuadronombre.grid(row=0, column=1, pady=10, padx=10)
cuadronombre.config(fg="red", justify="center")

cuadropass=Entry(miframe)
cuadropass.grid(row=1, column=1, pady=10, padx=10)
cuadropass.config(show="*")

cuadroapellido=Entry(miframe, textvariable=apellidos)
cuadroapellido.grid(row=2, column=1, pady=10, padx=10)

cuadroSapeliido=Entry(miframe, textvariable=segapellido)
cuadroSapeliido.grid(row=3, column=1, pady=10, padx=10)

loscometarios=Text(miframe, width=16, height=7)
loscometarios.grid(row=4, column=1, pady=10, padx=10)

scrolvert=Scrollbar(miframe, command=loscometarios.yview)
scrolvert.grid(row=4, column=2, sticky="nsew")

loscometarios.config(yscrollcommand=scrolvert.set)

minombre=Label(miframe, text="nombre:")
minombre.grid(row=0, column=0, sticky="e", pady=10, padx=10)

mipass=Label(miframe, text="password:")
mipass.grid(row=1, column=0, sticky="e", pady=10, padx=10)

miapellido=Label(miframe, text="apellido:")
miapellido.grid(row=2, column=0, sticky="e", pady=10, padx=10)

miSapeloo=Label(miframe, text="segundo apellido:")
miSapeloo.grid(row=3, column=0, sticky="e", pady=10, padx=10)

comentarioslbl=Label(miframe, text="comentarios:")
comentarioslbl.grid(row=4, column=0, sticky="e", pady=10, padx=10)

def codigoBoton():
	minombress.set("daniela")
	apellidos.set("ramirez")
	segapellido.set("ramirez")


miboton=Button(bott, text="Enviar", command=codigoBoton)
miboton.pack()


bott.mainloop()