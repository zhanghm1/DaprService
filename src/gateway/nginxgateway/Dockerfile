# ÉèÖÃ»ù´¡¾µÏñ
FROM nginx:alpine

#ÖØÐ´nginx ÅäÖÃ£¬\n\ »»ÐÐ
RUN echo $'server {                                 \n\
    listen       80;                                \n\
    listen  [::]:80;                                \n\
    server_name  localhost;                         \n\
    location /api/order/ {                          \n\
        proxy_pass   http://daprtest.orderapi/;     \n\
    }                                               \n\
    location /api/product/ {                        \n\
        proxy_pass   http://daprtest.productapi/;   \n\
    }                                               \n\
    location /api/member/ {                         \n\
        proxy_pass   http://daprtest.memberapi/;    \n\
    }                                               \n\
    location /api/pay/ {                            \n\
        proxy_pass   http://daprtest.payapi/;       \n\
    }                                               \n\
    location /api/tenant/ {                         \n\
        proxy_pass   http://daprtest.tenantapi/;    \n\
    }                                               \n\
    location /api/store/ {                          \n\
        proxy_pass   http://daprtest.storeapi/;     \n\
    }                                               \n\
}                                                   \n\
' >/etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]