from tkinter import *
from tkinter import messagebox

root=Tk()
def infoadiiconal():
	messagebox.showinfo("Procesador de Daniela", "Procesador de textos 2020")

def avisolicencia():
	messagebox.showwarning("Licencia", "producto bajo Licencia GNU")

def saliaplicacion():
	#valor=messagebox.askquestion("salir", "deseas salir?") este resibe yes o now
	valor=messagebox.askokcancel("salir", "deseas salir?")# este resibe true o false
	if valor==True:
		root.destroy()
def cerrardocumento():
	valor=messagebox.askretrycancel("reintentar", "no es posible cerrar. documento bloqueado")
	if valor==False:
		root.destroy()



barramenu=Menu(root)
root.config(menu=barramenu, width=300, height=300)
#expecificamos donde se va a mostrae los dato se la barra
archivomenu=Menu(barramenu, tearoff=0)
#agregamos mas items al menu
archivomenu.add_command(label="Nuevo")
archivomenu.add_command(label="Guardar")
archivomenu.add_command(label="Guardar como")
archivomenu.add_separator()
archivomenu.add_command(label="Cerrar", command=cerrardocumento)
archivomenu.add_command(label="Salir", command=saliaplicacion)


archivoedicion=Menu(barramenu, tearoff=0)
archivoedicion.add_command(label="Cortar")
archivoedicion.add_command(label="Copiar")
archivoedicion.add_command(label="Pegar")

archivoherramientras=Menu(barramenu, tearoff=0)

archivoayuda=Menu(barramenu,tearoff=0)
archivoayuda.add_command(label="Acerca de", command=infoadiiconal)
archivoayuda.add_command(label="Documentacion", command=avisolicencia)



barramenu.add_cascade(label="archivo", menu=archivomenu)
barramenu.add_cascade(label="Edicion", menu=archivoedicion)
barramenu.add_cascade(label="Herramientas", menu=archivoherramientras)
barramenu.add_cascade(label="Ayuda", menu=archivoayuda)


root.mainloop()