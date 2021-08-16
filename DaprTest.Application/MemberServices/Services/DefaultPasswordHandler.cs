using DaprTest.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Application.MemberServices
{
    public class DefaultPasswordHandler : IPasswordHandler
    {
        public DefaultPasswordHandler()
        { 
        
        }

        public string GetPasswordHash(string passwordSecert, string password)
        {
            return Sha256(passwordSecert, password);
        }

        public string GetPasswordSecert()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }

        public bool VerifyPassword(string passwordHash, string passwordSecert, string password)
        {
           return passwordHash == Sha256(passwordSecert, password);
        }
        private string Sha256(string passwordSecert, string password)
        {
            byte[] b = Encoding.Default.GetBytes(passwordSecert+ password); 
           return Convert.ToBase64String(b);
        }
    }
}
