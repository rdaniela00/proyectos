#Crea un programa que pida por teclado “Nombre”, “Dirección” y “Tfno”. Esos tres datos deberán ser almacenados en una lista 
# mostrar en consola el mensaje: “Los datos personales son: nombre apellido teléfono” (Se mostrarán los datos introducidos 
#por teclado).

nombre= input("ingresa un nombre")
direccion=input("ingresa direccion")
telefno=input("ingresa el numero")

milista=[nombre, direccion, telefno]

print("mis datos personales son:" +milista[0]+" "+milista[1]+" " +milista[2])