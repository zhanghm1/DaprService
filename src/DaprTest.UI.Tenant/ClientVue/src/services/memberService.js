import axios from '../common/request';
const serviceName="member";
const memberService={
    getList:(params)    =>axios.get(`/api/${serviceName}/member`,params),
    getDetail:(params)  =>axios.get(`/api/${serviceName}/member`,params),
    post:(data)        =>axios.post(`/api/${serviceName}/member`,data),
    put:(data)          =>axios.put(`/api/${serviceName}/member`,data),
    delete:(params)  =>axios.delete(`/api/${serviceName}/member`,params),
};

export default memberService;