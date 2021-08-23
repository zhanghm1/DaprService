using DaprTest.Application.AccountServices;
using DaprTest.Domain;
using DaprTest.Domain.Data;
using DaprTest.Domain.Entities.Admins;
using DaprTest.Domain.Entities.Tenants;
using DaprTest.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.TenantApi.Data
{
    public class TenantDbSeedData : IDbSeedData
    {
        private IAccountManage<TenantStaff, TenantDbContext> _accountManage;
        private TenantDbContext _tenantDbContext;
        public TenantDbSeedData(IAccountManage<TenantStaff, TenantDbContext> accountManage, TenantDbContext tenantDbContext)
        {
            _accountManage = accountManage;
            _tenantDbContext = tenantDbContext;
        }

        public async Task Init()
        {
            foreach (var item in TenantStaffData.List)
            {
                if (!await _accountManage.AnyByUserName(item.UserName))
                {
                    var member = new TenantStaff()
                    {
                        UserName = item.UserName,
                        Email = item.Email,
                        Name = item.Name,
                        PhoneNumber = item.PhoneNumber,
                        TenantCode=item.TenantCode,
                        StoreId=item.StoreId
                    };
                    await _accountManage.Create(member, item.Password);
                }
            }
            
            await _tenantDbContext.SaveChangesAsync();
        }
    }
}
