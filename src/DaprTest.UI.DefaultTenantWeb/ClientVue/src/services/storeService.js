import axios from '../common/request';

const serviceName="store";
const storeService={
    getList:(params)    =>axios.get(`/api/${serviceName}/store`,params),
    getDetail:(params)  =>axios.get(`/api/${serviceName}/store`,params),
    post:(data)        =>axios.post(`/api/${serviceName}/store`,data),
    put:(data)          =>axios.put(`/api/${serviceName}/store`,data),
    delete:(params)  =>axios.delete(`/api/${serviceName}/store`,params),
};

export default storeService;