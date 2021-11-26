# Build environment - alpine Linux
FROM node:lts-alpine3.14 as build
WORKDIR /app
COPY package*.json ./
RUN npm ci --production
#ENV PATH /app/node_modules/.bin:$PATH
COPY . .
RUN npm run build

# Production environment
FROM nginx:alpine
COPY --from=build /app/build /usr/share/nginx/html
COPY nginx/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

