def devuelve_ciudades(*ciudades):
	for elemento in ciudades:
		#for subelemento in elemento:
			
		yield from elemento

ciudades_ana=devuelve_ciudades("madrid", "mexico", "saragoza", "guanajuato")
print(next(ciudades_ana))
print(next(ciudades_ana))