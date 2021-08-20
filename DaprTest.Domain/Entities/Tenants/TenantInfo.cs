using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Entities.Tenants
{
    /// <summary>
    /// 商户
    /// </summary>
    public class TenantInfo : EntityBase
    {
        public string Name { get; set; }
        public string TenantCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
