using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain
{
    public interface IUserBase: IEntityIdBase
    {
        string UserName { get; set; }
        string Name { get; set; }
        string PasswordSecert { get; set; }
        string PasswordHash { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
    }
}
