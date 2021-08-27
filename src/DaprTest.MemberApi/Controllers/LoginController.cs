using DaprTest.Application.AccountServices;
using DaprTest.Domain.Entities.Admins;
using DaprTest.Domain.Entities.Members;
using DaprTest.MemberApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.MemberApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : LoginBaseController
    {
        private readonly ILogger<LoginController> _logger;
        private IAccountManage<Member, MemberDbContext> _accountManage;
        public LoginController(ILogger<LoginController> logger, IAccountManage<Member, MemberDbContext> accountManage)
        {
            _logger = logger;
            _accountManage = accountManage;
        }
        [AllowAnonymous]
        [HttpPost]
        public override async Task<LoginResponseModel> Post(LoginRequestModel model)
        {
            LoginResponseModel resp = new LoginResponseModel();
            Member member = await _accountManage.GetAccountByUserName(model.UserName);
            if (_accountManage.CheckPassword(member, model.Password))
            {
                resp = new LoginResponseModel()
                {
                    Id = member.Id,
                    Name = member.Name,
                    UserName = member.UserName,
                    Status = true,
                };
            }
            return resp;
        }
    }
}
