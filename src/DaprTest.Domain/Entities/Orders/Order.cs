using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain
{
    public class Order : EntityTenantBase
    {
        public string OrderNo { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public decimal OrderAmount { get; set; }
        public string Address { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
    public enum OrderStatus
    {
        /// <summary>
        /// 待支付
        /// </summary>
        WaitPay=100,
        /// <summary>
        /// 待发货
        /// </summary>
        WaitSend=200,
        /// <summary>
        /// 待收货
        /// </summary>
        WaitReceipt=300,
        /// <summary>
        /// 待评价
        /// </summary>
        WaitEvaluation=400,
        /// <summary>
        /// 完成
        /// </summary>
        Complete=500
    }
    
}
