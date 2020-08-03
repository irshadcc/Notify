FROM python:3.8

COPY . /app

WORKDIR /app

RUN apt update -y \
    && apt install tesseract-ocr -y \
    && pip3 install -r requirements.txt 

ENV FLASK_APP=app.py

ENV FLASK_ENV=production

EXPOSE 5000

ENTRYPOINT ["flask"] 

CMD ["run"]


