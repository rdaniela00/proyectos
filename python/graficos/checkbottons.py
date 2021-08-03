from tkinter import *

root=Tk()
root.title("Ejemplo")

playa=IntVar()
desierto=IntVar()
selva=IntVar()

def opciones_viaje():
	opcionescogida=""
	if (playa.get()==1):
		opcionescogida+="playa"
	if(desierto.get()==1):
		opcionescogida+="desierto"
	if(selva.get()==1):
		opcionescogida+="selva"
	textofinal.config(text=opcionescogida)

foto=PhotoImage(file="descarga.png")
Label(root, image=foto).pack()

frame=Frame(root)
frame.pack()

Label(frame, text="elige destinos", width=50).pack()

Checkbutton(frame, text="playa", variable=playa, onvalue=1, offvalue=0, command=opciones_viaje).pack()
Checkbutton(frame, text="desierto", variable=desierto, onvalue=1, offvalue=0, command=opciones_viaje).pack()
Checkbutton(frame, text="selva", variable=selva, onvalue=1, offvalue=0, command=opciones_viaje).pack()

textofinal=Label(frame)
textofinal.pack()



root.mainloop()