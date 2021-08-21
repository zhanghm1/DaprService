using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Data
{
    public class AdminUserData
    {
       public static List<AddAccountDto> List = new List<AddAccountDto>() {
                new AddAccountDto()
                {
                    UserName="admin",
                    Email="admin@admin.com",
                    Name="admin",
                    Password="123456",
                    PhoneNumber="130xxxxxxxx",
                },
            };
    }
}
