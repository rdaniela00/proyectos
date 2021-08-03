import re 

nombre1="daniela ramirez"
nombre2="gabriel ramirez"
nombre3="isabella nuñez"

if re.match("daniela", nombre3):
	print("hemos encontrado el nombre")
else:
	print("no hemos encontrado el ")