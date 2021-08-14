using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public string ProductModel { get; set; }
        public decimal OrderAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
    public enum OrderStatus
    {
        WaitPay=0,
        WaitSend,
        WaitReceipt,
        WaitEvaluation,
        Complete
    }
}
