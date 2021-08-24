using DaprTest.Application.AccountServices;
using DaprTest.Domain.Entities.Admins;
using DaprTest.Domain.Entities.Members;
using DaprTest.Domain.Entities.Tenants;
using DaprTest.EFCore;
using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DaprTest.IdentityServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IAccountManage<Member,MemberDbContext> _memberAccountManage;
        private readonly IAccountManage<TenantStaff, TenantDbContext> _tenantStaffAccountManage;
        private readonly IAccountManage<AdminUser, AdminDbContext> _adminUserAccountManage;
        private readonly AdminDbContext _adminDbContext;
        private readonly MemberDbContext _memberDbContext;
        private readonly TenantDbContext _tenantDbContext;
        public AccountController(IIdentityServerInteractionService interaction
             , IAccountManage<Member, MemberDbContext> memberAccountManage
             , IAccountManage<TenantStaff, TenantDbContext> tenantStaffAccountManage
             , IAccountManage<AdminUser, AdminDbContext> adminUserAccountManage
             , AdminDbContext adminDbContext
            , MemberDbContext memberDbContext
            , TenantDbContext tenantDbContext
            )
        {
            _interaction = interaction;
            _memberAccountManage = memberAccountManage;
            _tenantStaffAccountManage = tenantStaffAccountManage;
            _adminUserAccountManage = adminUserAccountManage;
            _adminDbContext = adminDbContext;
            _memberDbContext = memberDbContext;
            _tenantDbContext = tenantDbContext;
        }
        public IActionResult Login(string returnUrl)
        {
            LoginModel resp = new LoginModel()
            {
                ReturnUrl = returnUrl
            };
            return View(resp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Login(LoginInputModel model)
        {
            bool checkPassword = false;
            IdentityServerUser user = null;
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);

            var client = await _adminDbContext.ApplicationClients.Where(a => a.ClientId == context.Client.ClientId).FirstOrDefaultAsync();
            switch (client.ClientType)
            {
                case ClientType.MemberClient:
                    {
                        var account = await _memberDbContext.Members.Where(a=>a.UserName==model.UserName&& a.TenantCode== client.TenantCode).FirstOrDefaultAsync();
                        if (account == null)
                        {

                        }
                        checkPassword = _memberAccountManage.CheckPassword(account, model.Password);
                        user = new IdentityServerUser(account.Id.ToString())
                        {
                            DisplayName = account.UserName,
                            AdditionalClaims = new List<Claim>(){
                                new Claim("ClientType","MemberClient"),
                            },
                        };
                    }
                    break;
                case ClientType.TenantClient:
                    {
                        if (string.IsNullOrEmpty(model.TenantCode))//商户平台登录需要选择需要登录的平台
                        {
                            var staffs = await _tenantDbContext.TenantStaffs.Where(a => a.UserName == model.UserName).Select(a=>a.TenantCode).ToListAsync();
                            if (staffs != null)
                            {
                                LoginModel resp = new LoginModel();
                                resp.Tenants = await _adminDbContext.TenantInfos.Where(a => staffs.Contains(a.TenantCode)).Select(a => new LoginTenantModel()
                                {
                                    Name = a.Name,
                                    TenantCode = a.TenantCode
                                }).ToListAsync();
                                return View(resp);
                            }
                        }
                        else
                        {
                            var account = await _tenantDbContext.TenantStaffs.Where(a => a.UserName == model.UserName && a.TenantCode == model.TenantCode).FirstOrDefaultAsync();
                            if (account == null)
                            {

                            }
                            checkPassword = _tenantStaffAccountManage.CheckPassword(account, model.Password);
                            user = new IdentityServerUser(account.Id.ToString())
                            {
                                DisplayName = account.UserName,
                                AdditionalClaims = new List<Claim>(){
                                new Claim("ClientType","TenantClient"),
                            },
                            };
                        }
                        
                    }
                    break;
                case ClientType.AdminClient:
                    {
                        var account = await _adminUserAccountManage.GetAccountByUserName(model.UserName);
                        if (account == null)
                        {

                        }
                        checkPassword = _adminUserAccountManage.CheckPassword(account, model.Password);
                        user = new IdentityServerUser(account.Id.ToString())
                        {
                            DisplayName = account.UserName,
                            AdditionalClaims = new List<Claim>(){
                                new Claim("ClientType","AdminClient"),
                            },
                        };
                    }
                    break;
            }

            if (checkPassword)
            {
                AuthenticationProperties props = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(3)
                };

                var aaa = user.CreatePrincipal();

                await HttpContext.SignInAsync(user, props);

                if (context != null)
                {
                    return Redirect(model.ReturnUrl);
                }
            }
            return View();
        }

        public IActionResult Logout(string logoutId)
        {
            
            return View();
        }
    }
    public class LoginInputModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string TenantCode { get; set; }
        public bool RememberLogin { get; set; }
    }
    public class LoginModel
    {
        public LoginModel()
        { 
        
        }
        public LoginModel(LoginInputModel loginInput)
        {
            UserName = loginInput.UserName;
            Password = loginInput.Password;
            ReturnUrl = loginInput.ReturnUrl;
            TenantCode = loginInput.TenantCode;
            RememberLogin = loginInput.RememberLogin;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string TenantCode { get; set; }
        public bool RememberLogin { get; set; }
        
        public List<LoginTenantModel> Tenants { get; set; }
    }
    public class LoginTenantModel
    {
        public string Name { get; set; }
        public string TenantCode { get; set; }
    }
}
