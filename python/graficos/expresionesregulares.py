import re
 #importa el metod expresiones regulares
cadena="vamos a aprender expresiones regulares en python. python es un lenguaje de sintaxis sensilla"
#encuentra este texto
textobuscar="python"
#si re.sherch (texto, candea)no es none
'''if re.search(textobuscar, cadena) is not None:
	print("he encontrado en texxxxxxxxxxxxxxxxxto")
else:
	print("no he encontrado el texto")'''

	#--------------------------------
'''textoencontrae=re.search(textobuscar, cadena)

print(textoencontrae.start())
print(textoencontrae.end())'''
print(len(re.findall(textobuscar, cadena)))


