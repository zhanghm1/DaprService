using Dapr.Client;
using DaprTest.Application.AccountServices;
using DaprTest.Domain.Entities.Admins;
using DaprTest.Domain.Entities.Members;
using DaprTest.Domain.Entities.Tenants;
using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DaprTest.IdentityServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly DaprClient _daprClient;
        public AccountController(IIdentityServerInteractionService interaction, DaprClient daprClient)
        {
            _interaction = interaction;
            _daprClient = daprClient;
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
            

            var client = await _daprClient.InvokeMethodAsync<ApplicationClient>(HttpMethod.Get, "adminapi", "ApplicationClient");
            switch (client.ClientType)
            {
                case ClientType.MemberClient:
                    {
                        var account = await _daprClient.InvokeMethodAsync<Member>(HttpMethod.Get, "memberapi", "login");
                        if (account == null)
                        {

                        }
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
                            LoginModel resp = new LoginModel();
                            var listTenant = await _daprClient.InvokeMethodAsync<List<TenantInfo>>(HttpMethod.Post, "tenantapi", "login");
                            resp.Tenants = listTenant.Select(a => new LoginTenantModel()
                            {
                                Name = a.Name,
                                TenantCode = a.TenantCode
                            }).ToList();
                            return View(resp);
                        }
                        else
                        {
                            var account = await _daprClient.InvokeMethodAsync<TenantStaff>(HttpMethod.Post, "tenantapi", "login");

                            if (account == null)
                            {

                            }
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
                        var account = await _daprClient.InvokeMethodAsync<AdminUser>(HttpMethod.Post, "adminapi", "login");
                        if (account == null)
                        {

                        }
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
