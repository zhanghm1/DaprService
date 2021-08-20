using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Entities.Pays
{
    public class PaymentChannel : EntityTenantBase
    {
        public string Name { get; set; }
        public string MerchantID { get; set; }
        public string AppId { get; set; }
        public string AppSecert { get; set; }
    }
}
