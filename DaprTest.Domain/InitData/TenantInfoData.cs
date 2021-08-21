using DaprTest.Domain.Entities.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Data
{
   public class TenantInfoData
    {
        public static string DefaultTenantCode = "DefaultTenant";
        public static List<TenantInfo> List = new List<TenantInfo>() {
                new TenantInfo()
                {
                    TenantCode=DefaultTenantCode,
                    Address="测试地址",
                    Phone="130xxxxxxxx",
                    Email="TestTenant@TestTenant.com",
                    Name=DefaultTenantCode,
                },
            };
    }
}
