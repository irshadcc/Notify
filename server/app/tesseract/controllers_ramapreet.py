from flask import Blueprint,request,make_response
from PIL import Image
import base64
import json
from tesserocr import PyTessBaseAPI, RIL
import cv2
import os
import numpy as np
import base64
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

        img = cv2.cvtColor(np.array(image), cv2.COLOR_RGB2BGR)
        final = img.copy()
        resultant_text = ''
        with PyTessBaseAPI() as api:
            api.SetImage(image)
            boxes = api.GetComponentImages(RIL.BLOCK, True)
            for i, (im,box,_,_) in enumerate(boxes):
                api.SetRectangle(box['x'],box['y'],box['w'],box['h'])
                conf_mean = api.MeanTextConf()
                if conf_mean >= 80:
                    cv2.rectangle(final, (box['x'],box['y']), (box['x']+box['w'],box['y']+box['h']), (255,255,255), -1)
                    result = api.GetUTF8Text()
                    resultant_text+=result
        img_grey = cv2.cvtColor(final, cv2.COLOR_BGR2GRAY)
        thresh = 128
        img_binary = cv2.threshold(img_grey, thresh, 255, cv2.THRESH_BINARY)[1]
        img_binary = 255*(img_binary < 254).astype(np.uint8) # To invert the text to white
        coords = cv2.findNonZero(img_binary) # Find all non-zero points (text)
        x, y, w, h = cv2.boundingRect(coords) # Find minimum spanning bounding box
        rect = final[y:y+h, x:x+w] # Crop the image - note we do this on the original image
        ans = ''
        if len(rect)!=0:
            im_b64 = base64.b64encode(rect.tobytes())
            ans = '<p><p>' + resultant_text + '</p><br />' + '<p>' + '<img width="100%" src="data:image/png;base64,' + im_b64 + '/>' + '</p></p>' 
        else:
            ans = '<p>' + resultant_text + '</p>'

    except Exception as e:

        print(str(e))
        return False 


    return ans
    
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
