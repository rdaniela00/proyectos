import os
import time
import threading
from tkinter import *
from tkinter import Button, Tk, HORIZONTAL
from tkinter.ttk import Progressbar
from tkinter import messagebox

root = Tk()
root.title("App v0.1")
root.geometry("600x320")


#root.iconbitmap(os.path.join(os.getcwd(), 'favicon.ico'))

runButton = Button(root, text='Comenzar Descarga')
percent = Label(root, text="", anchor=S) 
progress = Progressbar(root, length=500, mode='determinate')    
status = Label(root, text="Haga clic en el boton Para iniciar proceso", relief=SUNKEN, anchor=W, bd=2) 


runButton.pack(pady=15)
percent.pack()
progress.pack()
status.pack(side=BOTTOM, fill=X)

root.mainloop()

