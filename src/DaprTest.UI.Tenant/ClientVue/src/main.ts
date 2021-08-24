import { createApp } from 'vue'
import ElementPlus from 'element-plus';
import 'element-plus/lib/theme-chalk/index.css';
import App from './App.vue';
import router  from './router/index';

import axios from 'axios';
import VueAxios from 'vue-axios';



axios.defaults.baseURL = 'http://localhost:5102';
axios.defaults.headers.common['Authorization'] = "";
axios.defaults.headers.post['Content-Type'] = 'application/josn';

axios.interceptors.request.use(function (config) {
// Do something before request is sent
    return config;
}, function (error) {
// Do something with request error
    return Promise.reject(error);
});

// Add a response interceptor
axios.interceptors.response.use(function (response) {
// Any status code that lie within the range of 2xx cause this function to trigger
// Do something with response data
    return response;
}, function (error) {
// Any status codes that falls outside the range of 2xx cause this function to trigger
// Do something with response error
    return Promise.reject(error);
});


const app = createApp(App);
app.use(router);
app.use(ElementPlus);
app.use(VueAxios, axios);
app.mount('#app');