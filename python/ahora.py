config = configparser.ConfigParser()


config.read('example.ini')

config.sections()
	['bitbucket.org', 'topsecret.server.com']
	'bitbucket.org' in config
True
	'bytebong.com' in config
False
	config['bitbucket.org']['User'] ='hg'

config['DEFAULT']['Compression']
'yes'
topsecret = config['topsecret.server.com']
topsecret['ForwardX11']
'no'
topsecret['Port']
'50022'
for key in config['bitbucket.org']:  
     print(key)
user
compressionlevel
serveraliveinterval
compression
forwardx11
config['bitbucket.org']['ForwardX11']
'yes'