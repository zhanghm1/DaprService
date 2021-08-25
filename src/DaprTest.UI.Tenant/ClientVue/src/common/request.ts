import axios from 'axios';

axios.defaults.baseURL = 'http://localhost:5102';
axios.defaults.headers.common['Token'] = "OTkyYTc0Y2JkZmY0NGFkNzgyMjVkODRiNzUwOTAxZDA%253D";
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
    async get<T=any>(url:string,params:any){
       let resp = await axios.get(this.paramsToUrl(url,params));
       return resp.data as T;
    },
    async delete<T=any>(url:string,params:any){
        let resp =  await axios.delete(this.paramsToUrl(url,params));
        return resp.data as T;
    },
    async post<T=any>(url:string,data:any){
        let resp =  await axios.post(url,data)
        return resp.data as T;
    },
    async put<T=any>(url:string,data:any){
        let resp =  await axios.put(url,data)
        return resp.data as T;
    },
    
    paramsToUrl(url:string,params:any){
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