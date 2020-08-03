import base64
import requests

import pytesseract
import io
from PIL import Image

red='\033[31m'
green='\033[32m'
blue='\033[34m'


url = 'http://localhost:5000/recognize'

def test_img(img_path,exp_result=None) :
    """
        img_path : Image path 
        exp_result : Expected text for testing purposes

    """


    with open(img_path,'rb') as img_file : 
        data = base64.b64encode(img_file.read())
        data_str = data.decode("utf-8")


        res = requests.post(url,json={'image' : data_str , 'source' : 'python'})
        result = res.json()

        if exp_result == None : 
            print(blue,result)
            return None
        if result == exp_result : 
            print(green,u'\u2713' ,blue,img_path)
        else : 
            print(red,u'\u2716',blue ,img_path)


def test_encode_decode_python(img_path):

    # Open the Binary Image file
    file = open(img_path,'rb')
    data = base64.b64encode(file.read())
    data_str = data.decode("utf-8")


    data_bytes = bytes(data_str,'utf-8')
    data_dec = base64.decodebytes(data_bytes)
    image_bin = io.BytesIO(data_dec)
    image = Image.open(image_bin)


def test_encode_decode_js(img_path):
    

    # Open the encoded base64 image string from text file
    file = open(img_path,'r')
    data_str = file.read()
    data_str = data_str.split('base64')[-1].strip()

    data_dec = base64.b64decode(data_str)
    image_bin = io.BytesIO(data_dec)
    image = Image.open(image_bin)



# test_encode_decode('img3.jpg')
# test_encode_decode_js('file.txt')

test_img('img.jpg')
      



