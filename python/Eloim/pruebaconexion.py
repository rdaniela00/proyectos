import pyodbc 
import pymysql


# Some other example server values are
# server = 'localhost\sqlexpress' # for a named instance
# server = 'myserver,port' # to specify an alternate port
puerto = '3306'
server = 'localhost' 
database = 'pventa' 
username = 'USUARIO' 
password = 'PASS' 


cnxn = pymysql.connect('SERVER='+server+';DATABASE='+database+';UID='+username+';PWD='+ password)
cursor = cnxn.cursor()        
  



print(cnxn)