using DaprTest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Entities.Members
{
    public class Member : EntityTenantBase, IUserBase
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 生成一个随机数,不可泄露
        /// </summary>
        public string PasswordSecert { get; set; }
        /// <summary>
        /// 使用随机数+密码 加密,不可泄露
        /// </summary>
        public string PasswordHash { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
