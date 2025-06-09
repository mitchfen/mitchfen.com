FROM nginx:alpine

RUN apk update \
    && apk upgrade \
    && rm -rf /var/cache/apk/*

COPY nginx.conf /etc/nginx/nginx.conf
RUN chown nginx:nginx /etc/nginx/nginx.conf \
    && chmod 644 /etc/nginx/nginx.conf

COPY ./wwwroot /usr/local/webapp/nginx/html
RUN chown -R nginx:nginx /usr/local/webapp/nginx/html \
    && chmod -R 755 /usr/local/webapp/nginx/html

USER nginx

EXPOSE 80

LABEL org.opencontainers.image.description="Mitchell Fenner's personal website. Built with Blazor."
