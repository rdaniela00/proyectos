import sys, os, traceback, types

def isUserAdmin():
    if os.name == 'nt':

        import ctypes
        print(ctypes.windll.shell32.IsUserAnAdmin())

    else:
         raise RuntimeError("Unsupported operating system for this module: %s" % (os.name,))

isUserAdmin()

