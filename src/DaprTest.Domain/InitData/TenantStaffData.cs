using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Data
{
    public class TenantStaffData
    {
        public static List<AddAccountDto> List = new List<AddAccountDto>() {
                new AddAccountDto()
                {
                    UserName="Staff1",
                    Email="Staff1@Staff1.com",
                    Name="Staff1",
                    Password="123456",
                    PhoneNumber="130xxxxxxxx",
                    StoreId=StoreInfoData.DefaultStoreId,
                    TenantCode=TenantInfoData.DefaultTenantCode,
                },
            };
    }
}
