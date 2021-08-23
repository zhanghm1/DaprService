using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Entities.Tenants
{
    /// <summary>
    /// 商户员工
    /// </summary>
    public class TenantStaff : EntityTenantBase, IUserBase
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordSecert { get; set; }
        public string PasswordHash { get; set; }
        public string StoreId { get; set; }
    }
}
