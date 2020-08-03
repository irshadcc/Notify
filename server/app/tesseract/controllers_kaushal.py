from flask import Blueprint,request,make_response
from PIL import Image
import base64
import json
from tesserocr import PyTessBaseAPI, RIL
import cv2
import os
import numpy as np
import base64
import io 
from io import BytesIO
from random import randint

tesseract_bp = Blueprint('tesseract', __name__)

def recognize_image(img_string,source):
 
    try :

        image = None 
        if source == 'js' : 
            if 'data:' in img_string:
                img_string = img_string.split('base64,')[-1].strip()

            image_bytes = io.BytesIO(base64.b64decode(img_string))
            image = Image.open(image_bytes)

        if source == 'python' : 
            image_bytes = bytes(img_string,'utf-8')
            image_dec = base64.decodebytes(image_bytes)
            image_bin = io.BytesIO(image_dec)
            image = Image.open(image_bin)

        resultant_text = ''
        with PyTessBaseAPI() as api:
            api.SetImage(image)
            boxes = api.GetComponentImages(RIL.BLOCK, True)
            for i, (im,box,_,_) in enumerate(boxes):
                api.SetRectangle(box['x'],box['y'],box['w'],box['h'])
                conf_mean = api.MeanTextConf()
                if conf_mean >= 80:
                    result = api.GetUTF8Text()
                    resultant_text += result


    except Exception as e:

        print(str(e))
        return False 


    return resultant_text
    
@tesseract_bp.route('/',methods=['GET'])
def hello_world() : 
    return 'Hello world' 

@tesseract_bp.route('/recognize',methods=['POST'])
def recognize():   

    data = request.json
    
    # Data Validation
    if not data : 
        return { "error" : "No data sent " }

    if 'image' not in data or 'source' not in data: 
        return { "error" : "Please send json in { 'image' : base64encoded , 'source' : 'js | python' " } 
    
    if data['source'] != 'js' and data['source'] != 'python' : 
        return { "error" : "Please send json in { 'image' : base64encoded , 'source' : 'js | python' " } 
    
 
    text =recognize_image(data['image'],data['source'])
    

    # Error Check
    if not text :
        return { "error" : "Error in recognizing text " }


    return {'text' : text}
