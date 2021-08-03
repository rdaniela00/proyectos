#def generarPares(limite):

   ### num=1

   # milista=[]
   # while num<limite:
	   	#milista.append(num*2)
	   	#num=num+1
    #return milista


#print(generarPares(10))

def generaryiled(limite):
	num=1

	while num<limite:
		yield num*2
		num=num+1
devuelve_pares=generaryiled(10)

 
print(next(devuelve_pares))
print("aqui deve de ir texto")
print(next(devuelve_pares))
print("aqui deve de ir texto")
print(next(devuelve_pares))