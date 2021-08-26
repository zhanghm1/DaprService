FROM nginx:alpine

COPY ["DaprTest.UI.Tenant/ClientVue/dist", "/usr/share/nginx/html"]

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]