from io import open
archivo_tecto=open("archivo.txt", "w")

frase="estupendo dia para estudiar python"

archivo_tecto.write(frase)
archivo_tecto.close()