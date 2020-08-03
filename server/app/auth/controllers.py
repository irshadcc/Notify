from flask import Blueprint,request,current_app,make_response
from app import db
import jwt


auth_bp = Blueprint('auth', __name__)


@auth_bp.route('/register',methods=['POST'])
def register():

    db_conn = db.get_db('testdb')
    data = request.json

    required_fields = ['firstname','lastname','email','password']
    for required_field in required_fields : 
        if required_field not in data : 
            return {"error" : "${} not in the request".format(required_field) }

    user =  db_conn.users.find_one({ 'email': data['email'] }) 
    if user is not None : 
        return {"error" : "User already exists"}
    
    
    db_conn.users.insert_one(data)
    return {"message" : "Sign up successfull"}

@auth_bp.route('/login',methods=['POST'])
def login():

    db_conn = db.get_db('testdb')
    data = request.json
    
    required_fields = ['email','password']
    for required_field in required_fields : 
        if required_field not in data : 
            return {"error" : "${} not in the request".format(required_field) }

    user = db_conn.find_one({ 'email' : data['email']})
    if user == None or user['password'] != data['password'] :
        return { "error" : "Incorrect Username or password"}

    if user['password'] == data['password'] : 
        token  = jwt.encode({'id' : user['_id'] , 'email' : user['email']},current_app.config['SECRET_KEY'],algorithm='HS256')

        if data['cookie'] == 'true' : 
            resp = make_response({"message" : "Login Success","token" : token})
            print(type(resp))

 
# @auth_bp.route('/login')
# def login():
#     return "Hello"