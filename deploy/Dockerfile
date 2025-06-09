FROM nginx:alpine

RUN apk update \
    && apk upgrade \
    && rm -rf /var/cache/apk/*

COPY nginx.conf /etc/nginx/nginx.conf

COPY ./wwwroot /usr/local/webapp/nginx/html

EXPOSE 80

LABEL org.opencontainers.image.description="Mitchell Fenner's personal website. Built with Blazor."
