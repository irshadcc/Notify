export FLASK_APP="run.py"
# export FLASK_ENV="development"
export FLASK_ENV="production"
export SECRET_KEY="secret"


_flask() {
	
	flask run ;

}

_mongo() {

    	docker run -d -p 27017:27017 mongo		
}
_rm_pycache() {

    	find ./ -name __pycache__ -exec rm -rf "{}" \;
}
_setup_server() { 
	
	sudo apt-get update ;
	sudo apt-get install apache2 libapache2-mod-wsgi-py3 tesseract-ocr python3-pip tesseract-ocr libsm6 libxext6 libxrender-dev ;
	pip3 install virtualenv ;
	virtualenv venv ;
	./venv/bin/activate ;

	pip install -r requirements.txt
}
restart_server() {

	sudo rm -rf /var/log/apache2/* ;
	sudo apachectl restart ;
	echo "Server restarted " ; 
}


if [[ $1 == "flask" ]]; then
    _flask ;

elif [[ $1 == "mongo" ]]; then
    _mongo ;
elif [[ $1 == "restart_server" ]]; then
     restart_server ;
elif [[ $1 == "" ]]; then
    _rm_pycache

else 

    echo "\nPlease give any option"

fi
