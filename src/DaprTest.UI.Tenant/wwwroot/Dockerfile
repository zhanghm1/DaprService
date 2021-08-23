FROM nginx:alpine

COPY ["DaprTest.UI.Tenant/wwwroot", "/usr/share/nginx/html"]

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]