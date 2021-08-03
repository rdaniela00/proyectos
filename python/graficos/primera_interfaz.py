from tkinter import *

raiz=Tk()
raiz.title("ventana de Pruebas")
#raiz.resizable(0,0)
raiz.iconbitmap("chrome.ico")
#raiz.geometry("650x350")
raiz.config(bg="pink")

miframe=Frame()
miframe.pack(fill="both" ,expand="True")
miframe.config(bg="yellow")
miframe.config(width="650", height="350")
miframe.config(cursor="hand2")
raiz.mainloop()