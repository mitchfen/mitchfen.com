FROM nginx:alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY ./output/wwwroot /usr/local/webapp/nginx/html
EXPOSE 80
LABEL org.opencontainers.image.description "Mitchell Fenner's dockerized personal website 🐋"
