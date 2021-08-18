using DaprTest.Application.MemberServices;
using DaprTest.Domain.Entities.Members;
using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMemberAccountManage _memberAccountManage;
        public AccountController(IIdentityServerInteractionService interaction, IMemberAccountManage memberAccountManage)
        {
            _interaction = interaction;
            _memberAccountManage = memberAccountManage;
        }
        public IActionResult Login(string returnUrl)
        {
            LoginInputModel resp = new LoginInputModel()
            {
                ReturnUrl = returnUrl
            };
            return View(resp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Login(LoginInputModel model)
        {
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);

            var member = await _memberAccountManage.GetMemberByUserName(model.UserName);
            if (member==null)
            { 
            
            }
            if (await _memberAccountManage.CheckPassword(member, model.Password))
            {
                AuthenticationProperties props = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(3)
                };
                var isuser = new IdentityServerUser(member.Id.ToString())
                {
                    DisplayName = member.UserName
                };


                await HttpContext.SignInAsync(isuser, props);

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
        public bool RememberLogin { get; set; }
    }
}
