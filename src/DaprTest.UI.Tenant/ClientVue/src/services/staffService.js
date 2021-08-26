import axios from '../common/request';

const serviceName="staff";
const staffService={
    getList:(params)    =>axios.get(`/api/${serviceName}/staff`,params),
    getDetail:(params)  =>axios.get(`/api/${serviceName}/staff`,params),
    post:(data)        =>axios.post(`/api/${serviceName}/staff`,data),
    put:(data)          =>axios.put(`/api/${serviceName}/staff`,data),
    delete:(params)  =>axios.delete(`/api/${serviceName}/staff`,params),

    getStaffInfo:()=>axios.get(`/api/${serviceName}/staff/info`),
};

export default staffService;