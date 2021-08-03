import re

lista_nombre=['sandra gomez',
				'maria martin',
				'ana gomez',
				'santiago martin'
]

for elemento in lista_nombre:
	if re.findall('^santiago', elemento):
		print(elemento)