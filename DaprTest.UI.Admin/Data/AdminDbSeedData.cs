using DaprTest.Application.AccountServices;
using DaprTest.Domain.BaseModels;
using DaprTest.Domain.Data;
using DaprTest.Domain.Entities.Admins;
using DaprTest.EFCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.UI.Admin.Data
{
    public class AdminDbSeedData: IDbSeedData
    {
        private IAccountManage<AdminUser, AdminDbContext> _accountManage;
        private AdminDbContext _adminDbContext;
        public IConfiguration Configuration;
        public AdminDbSeedData(IAccountManage<AdminUser, AdminDbContext> accountManage, AdminDbContext adminDbContext, IConfiguration configuration)
        {
            _accountManage = accountManage;
            _adminDbContext = adminDbContext;
            Configuration = configuration;
        }

        public async Task Init()
        {
            foreach (var item in AdminUserData.List)
            {
                if (!await _accountManage.AnyByUserName(item.UserName))
                {
                    var member = new AdminUser()
                    {
                        UserName = item.UserName,
                        Email = item.Email,
                        Name = item.Name,
                        PhoneNumber = item.PhoneNumber,
                    };
                    await _accountManage.Create(member, item.Password);
                }
            }
            foreach (var item in ApplicationClientData.List)
            {
                if (!_adminDbContext.ApplicationClients.Any(a => a.ClientId == item.ClientId))
                {
                    string url = Configuration[item.ClientId + "Url"];
                    item.RedirectUris = url + item.RedirectUris;
                    item.LogoutRedirectUris = url + item.LogoutRedirectUris;

                    _adminDbContext.ApplicationClients.Add(item);
                }
            }
            foreach (var item in TenantInfoData.List)
            {
                if (!_adminDbContext.TenantInfos.Any(a => a.TenantCode == item.TenantCode))
                {
                    _adminDbContext.TenantInfos.Add(item);
                }
            }
            await _adminDbContext.SaveChangesAsync();
        }
    }
}
