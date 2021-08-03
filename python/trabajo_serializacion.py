import pickle

lista_nombres=["daniela", "jimena", "nilda", "keyla", "salma"]

fichero_binario=open("lista_nombres", "wb")

pickle.dump(lista_nombres, fichero_binario)
fichero_binario.close()

del(fichero_binario)