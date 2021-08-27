import axios from '../common/request';

const serviceName="product";
const productService={
    getList:(params)    =>axios.get(`/api/${serviceName}/product`,params),
    getDetail:(params)  =>axios.get(`/api/${serviceName}/product`,params),
    post:(data)        =>axios.post(`/api/${serviceName}/product`,data),
    put:(data)          =>axios.put(`/api/${serviceName}/product`,data),
    delete:(params)  =>axios.delete(`/api/${serviceName}/product`,params),
};

export default productService;