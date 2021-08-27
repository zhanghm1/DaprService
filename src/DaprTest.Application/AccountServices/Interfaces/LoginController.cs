using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Application.AccountServices
{
    public abstract class LoginBaseController: ControllerBase
    {

        public abstract Task<LoginResponseModel> Post(LoginRequestModel model);
        public virtual Task<List<StaffTenantResponseModel>> StaffTenant(StaffTenantRequestModel model) 
        {
            return null;
        }
    }
    public class LoginRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TenantCode { get; set; }
    }
    public class LoginResponseModel
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; }

        public string UserName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class StaffTenantRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class StaffTenantResponseModel
    {
        public string Name { get; set; }
        public string TenantCode { get; set; }
    }
}
