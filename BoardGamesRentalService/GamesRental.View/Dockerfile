FROM node:16-alpine AS client
#EXPOSE 4200 49153
EXPOSE 80 4200


WORKDIR /app

ENV PATH /app/node_modules/.bin$PATH
COPY GamesRental.View/package.json /app/package.json
RUN npm i
RUN npm install -g @angular/cli@11.2.0

COPY GamesRental.View/. /app

#ARG configuration=production
CMD ng serve --prod --disable-host-check
#CMD ["ng", "serve", "--port", "443", "--host", "0.0.0.0", "--disable-host-check", "--poll", "2000"]
CMD ng serve --host 0.0.0.0