using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Entities.Tenants
{
    public class StoreInfo:EntityTenantBase
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
    }
}
