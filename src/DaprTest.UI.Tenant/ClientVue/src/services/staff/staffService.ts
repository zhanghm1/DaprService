import axios from '../../common/request';
import {    StaffItemDto,
    StaffDetailDto,
    StaffAddDto,
    StaffUpdateDto} from './dtos';

const userService={
    getStaffList:(params:any)=>axios.get<Array<StaffItemDto>>("/api/Statistic/Statistic/MessageCount",params),
    getStaffDetail:(params:any)=>axios.get<StaffDetailDto>("/api/Statistic/Statistic/MessageCount",params),
    postStaff:(data:StaffAddDto)=>axios.post("/api/Statistic/Statistic/MessageCount",data),
    putStaff:(data:StaffUpdateDto)=>axios.put("/api/Statistic/Statistic/MessageCount",data),
    deleteStaff:(params:any)=>axios.delete("/api/Statistic/Statistic/MessageCount",params),
};

export default userService;