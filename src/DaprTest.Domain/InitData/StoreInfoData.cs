using DaprTest.Domain.Entities.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Data
{
   public class StoreInfoData
    {
        public static string DefaultStoreId = "dd21c898-c285-e013-ec06-f42be367de20";
        public static List<StoreInfo> List = new List<StoreInfo>() {
                new StoreInfo()
                {
                    Id=DefaultStoreId,
                    TenantCode=TenantInfoData.DefaultTenantCode,
                    Address="地址地址地址地址地址",
                    Position="1.135651313513515,2.153164613165",
                    Name="默认门店",
                },
            };
    }
}
