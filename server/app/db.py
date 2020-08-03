from flask import g,current_app
import pymongo


def get_db(db_name=None):
    
    if 'db' not in g: 
        g.db = pymongo.MongoClient(current_app.config['DB_HOST'],current_app.config['DB_PORT']) 

    if db_name == None : 
        return g.db
    else :
        return g.db[db_name]

