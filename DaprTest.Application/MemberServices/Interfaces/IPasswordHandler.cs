using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Application.MemberServices
{
    public interface IPasswordHandler
    {
        string GetPasswordSecert();
        string GetPasswordHash(string passwordSecert, string password);

        bool VerifyPassword(string passwordHash, string passwordSecert, string password);
    }
}
