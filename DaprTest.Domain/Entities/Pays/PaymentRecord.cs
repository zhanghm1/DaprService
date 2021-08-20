using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain.Entities.Pays
{
    public class PaymentRecord : EntityTenantBase
    {
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime PayTime { get; set; }
        public string PaymentChannelId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PayAmount { get; set; }
        public string Remark { get; set; }
        public string OrderNo { get; set; }
    }
}
