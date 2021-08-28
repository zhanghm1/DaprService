using DaprTest.Application.AccountServices;
using DaprTest.Domain.Entities.Admins;
using DaprTest.Domain.Entities.Members;
using DaprTest.Domain.Entities.Tenants;
using DaprTest.TenantApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.TenantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : LoginBaseController
    {
        private readonly ILogger<LoginController> _logger;
        private IAccountManage<TenantStaff, TenantDbContext> _accountManage;
        private TenantDbContext _tenantDbContext;
        public LoginController(ILogger<LoginController> logger
            , IAccountManage<TenantStaff, TenantDbContext> accountManage
            , TenantDbContext tenantDbContext
            )
        {
            _logger = logger;
            _accountManage = accountManage;
            _tenantDbContext = tenantDbContext;
        }
        [AllowAnonymous]
        [HttpPost]
        public override async Task<LoginResponseModel> Post(LoginRequestModel model)
        {
            LoginResponseModel resp = new LoginResponseModel();
            TenantStaff staff = await _accountManage.GetAccountByUserName(model.UserName);
            if (_accountManage.CheckPassword(staff, model.Password))
            {
                resp = new LoginResponseModel()
                {
                    Id = staff.Id,
                    Name = staff.Name,
                    UserName = staff.UserName,
                    Status = true,
                };
            }
            return resp;
        }
        [AllowAnonymous]
        [HttpPost("tenants")]
        public override async Task<List<StaffTenantResponseModel>> StaffTenant(StaffTenantRequestModel model)
        {
            List<StaffTenantResponseModel> resp = new List<StaffTenantResponseModel>();
            var tenants = _tenantDbContext.TenantStaffs.Where(a=>a.UserName== model.UserName).Select(a=>new StaffTenantResponseModel() { 
            Name=a.TenantName,
            TenantCode=a.TenantCode
            
            }).ToList();
            
            
            return tenants;
        }
    }
}
