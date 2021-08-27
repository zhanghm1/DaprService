using DaprTest.AdminApi.Data;
using DaprTest.Application.AccountServices;
using DaprTest.Domain.Entities.Admins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.AdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : LoginBaseController
    {
        private readonly ILogger<LoginController> _logger;
        private IAccountManage<AdminUser, AdminDbContext> _accountManage;
        public LoginController(ILogger<LoginController> logger, IAccountManage<AdminUser, AdminDbContext> accountManage)
        {
            _logger = logger;
            _accountManage = accountManage;
        }
        [AllowAnonymous]
        [HttpPost]
        public override async Task<LoginResponseModel> Post(LoginRequestModel model)
        {
            LoginResponseModel resp = new LoginResponseModel();
            AdminUser adminUser = await _accountManage.GetAccountByUserName(model.UserName);
            if (_accountManage.CheckPassword(adminUser, model.Password))
            {
                resp = new LoginResponseModel()
                {
                    Id = adminUser.Id,
                    Name = adminUser.Name,
                    UserName = adminUser.UserName,
                    Status = true,
                };
            }
            return resp;
        }
    }
}
