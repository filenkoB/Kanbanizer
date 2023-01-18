FROM node:alpine as build
WORKDIR /src

RUN npm install -g @angular/cli

COPY . .
RUN npm install && ng build

FROM nginx as runtime
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /src/dist /usr/share/nginx/html

EXPOSE 80