import axios from 'axios';

axios.defaults.baseURL = window.apiurl;
axios.defaults.headers.common['Authorization'] = "Bearer "+localStorage.getItem("access_token");
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

const proxyAxios={
    async get(url,params){
       let resp = await axios.get(this.paramsToUrl(url,params));
       return resp.data;
    },
    async delete(url,params){
        let resp =  await axios.delete(this.paramsToUrl(url,params));
        return resp.data;
    },
    async post(url,data){
        let resp =  await axios.post(url,data)
        return resp.data;
    },
    async put(url,data){
        let resp =  await axios.put(url,data)
        return resp.data;
    },
    
    paramsToUrl(url,params){
        if(params){
            for(let key in params){
                if(url.indexOf("?")==-1){
                    url=url+"?";
                }else{
                    url=url+"&";
                }
                url=url+key+"="+params[key];
            }
        }
        return url;
    }
};

export default proxyAxios;