FROM node:16-alpine AS client
EXPOSE 4200 49153

WORKDIR /app

ENV PATH /app/node_modules/.bin$PATH
COPY GamesRental.View/package.json /app/package.json
RUN npm i
RUN npm install -g @angular/cli@11.2.0

COPY GamesRental.View/. /app
#CMD ["ng", "serve", "--port", "4200", "--host", "0.0.0.0", "--disable-host-check", "--poll", "2000"]
CMD ng serve --host 0.0.0.0