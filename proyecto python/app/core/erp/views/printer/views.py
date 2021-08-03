import os, sys
import win32print
POSTICKET = win32print.GetDefaultPrinter()
#
# raw_data could equally be raw PCL/PS read from
#  some print-to-file operation
#para version de python
if sys.version_info >= (3,):
  #devuelve la cantidad completa de los bytes a la impreosra 
  raw_data = bytes("ESTA ES UNA PRUEBA", "utf-8")

else:
  raw_data = "ESTA ES UNA PRUEBA"

hPrinter = win32print.OpenPrinter(POSTICKET)
try:
  hJob = win32print.StartDocPrinter(hPrinter, 1, ("PRUEBA DE DATOS", None, "RAW"))
  try:
    win32print.StartPagePrinter(hPrinter)
    win32print.WritePrinter(hPrinter, raw_data)
    win32print.EndPagePrinter(hPrinter)
  finally:
    win32print.EndDocPrinter(hPrinter)
finally:
  win32print.ClosePrinter(hPrinter)
  
