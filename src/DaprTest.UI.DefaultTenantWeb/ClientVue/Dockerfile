FROM node as build-stage
WORKDIR /app
COPY ["DaprTest.UI.DefaultTenantWeb/ClientVue/package*.json", "./"] 
# RUN npm config set registry https://registry.npm.taobao.org
RUN npm install
COPY . .
COPY ["DaprTest.UI.DefaultTenantWeb/ClientVue", "./"] 
RUN npm run build


FROM nginx:alpine as production-stage
COPY --from=build-stage /app/dist /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
