import axios from '../common/request';

const serviceName="order";
const orderService={
    getList:(params)    =>axios.get(`/api/${serviceName}/order`,params),
    getDetail:(params)  =>axios.get(`/api/${serviceName}/order`,params),
    post:(data)        =>axios.post(`/api/${serviceName}/order`,data),
    put:(data)          =>axios.put(`/api/${serviceName}/order`,data),
    delete:(params)  =>axios.delete(`/api/${serviceName}/order`,params),
};

export default orderService;