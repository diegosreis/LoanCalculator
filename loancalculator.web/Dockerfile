FROM node:14 AS build
WORKDIR /app
COPY loancalculator.web/package.json ./
COPY loancalculator.web/package-lock.json ./
RUN npm install

COPY loancalculator.web/ ./
RUN npm run build
RUN ls -la /app


FROM nginx:stable-alpine AS runtime
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]