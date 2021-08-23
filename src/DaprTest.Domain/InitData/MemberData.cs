using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Data
{
    public class MemberData
    {
        public static List<AddAccountDto> List = new List<AddAccountDto>() {
                new AddAccountDto()
                {
                    UserName="member1",
                    Email="member1@member1.com",
                    Name="member1",
                    Password="123456",
                    PhoneNumber="130xxxxxxxx",
                    TenantCode=TenantInfoData.DefaultTenantCode,
                },
            };
    }
}
