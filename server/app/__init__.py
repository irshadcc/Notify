from flask import Flask


def create_app(test_config=None):

    app = Flask(__name__,instance_relative_config=True)

    # if test_config is None : 
    #     app.config.from_pyfile('config.py',silent=True)
    # else :
    #     app.config.from_mapping(test_config)
    # app.config['SECRET_KEY'] = app.config.from_envvar('SECRET_KEY')
    app.config['DB_HOST'] = 'localhost'
    app.config['DB_PORT'] = 27017

    with app.app_context() :

        # Supressing Auth module
        # from .auth.controllers import auth_bp
        # app.register_blueprint(auth_bp)
        from .tesseract.controllers import tesseract_bp
        app.register_blueprint(tesseract_bp)


    return app