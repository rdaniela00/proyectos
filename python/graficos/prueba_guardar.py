from tkinter import *
from tkinter import filedialog


root=Tk()

def abrir_fichero():
	fichero=filedialog.askopenfilename(title="abirrir", initialdir="C:", filetypes=(("ficheros exel", "*.xlsx"),
		("ficheros de texto", "*.txt"), ("todos los ficheros", "*.*")))
	print(fichero)
Button(root, text="abrir fichero", command=abrir_fichero).pack()

root.mainloop()