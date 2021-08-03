from tkinter import *

boot=Tk()
boot.title("aqui se pine mensaje de titulo")
#mi frame se asigna para poner widts puede tener una interfaz varios
miFame=Frame(boot, width="500", height="400")
#empaquetar para que se muestre en tk
miFame.pack()
miimagen=PhotoImage(file="descarga.png")
#esto sirvew para poner texto en untext
Label(miFame, text="hola mundo", fg="red", font=("Comic Sans MS", 18)).place(x=100, y=200)

#sirve para poner una imagen dentro de  un label
miimagen=PhotoImage(file="descarga.png")

Label(miFame, image=miimagen).place(x=100, y=200)




boot.mainloop()