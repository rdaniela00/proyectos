contador=0
miemail=input("escibe tu correo electronico")


for i in miemail:
	if (i=="@" or i=="."):
		contador=contador+1

if contador==2:
	print("el email es correcto")
else:
	print("el email es falso")








	