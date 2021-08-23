FROM nginx:alpine

COPY ["DaprTest.UI.DefaultTenantWeb/wwwroot", "/usr/share/nginx/html"]

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]