import sys
import logging

activate_this = '/home/ubuntu/venv/bin/activate_this.py'
with open(activate_this) as f:
	exec(f.read(), dict(__file__=activate_this))

# sys.stdout = open('output.txt','wr') 

logging.basicConfig(stream=sys.stderr)
sys.path.insert(0, '/var/www/html/server')

from run import app as application

