from tkinter import * 

raiz=Tk()

varopcion=IntVar()
def imprimir():
	#print(varopcion.get())
	if varopcion.get()==1:
		etiqueta.config(text="has elegido masculino")
	else:
		etiqueta.config(text="has elegido femenino")

Label(raiz, text="genero").pack()
Radiobutton(raiz, text="masculino", variable=varopcion, value=1, command=imprimir).pack()
Radiobutton(raiz, text="femenino", variable=varopcion, value=2, command=imprimir).pack()

etiqueta=Label(raiz)
etiqueta.pack()
raiz.mainloop()