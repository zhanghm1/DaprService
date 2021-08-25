import axios from '../../common/request';

const userService={
    getStaffList:(params)=>axios.get("/api/Statistic/Statistic/MessageCount",params),
    getStaffDetail:(params)=>axios.get("/api/Statistic/Statistic/MessageCount",params),
    postStaff:(data)=>axios.post("/api/Statistic/Statistic/MessageCount",data),
    putStaff:(data)=>axios.put("/api/Statistic/Statistic/MessageCount",data),
    deleteStaff:(params)=>axios.delete("/api/Statistic/Statistic/MessageCount",params),
};

export default userService;