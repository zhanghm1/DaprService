using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain
{
    /// <summary>
    /// 订单退款协商历史
    /// </summary>
    public class OrderReturnRecord : EntityTenantBase
    {
        public string OrderId { get; set; }
        public string OrderNo { get; set; }
        public string OrderItemId { get; set; }
        public string OperatorId { get; set; }
        public string OperatorName { get; set; }
        public AfterSaleStatus? AfterSaleStatus { get; set; }
        public string Content { get; set; }
    }

}
