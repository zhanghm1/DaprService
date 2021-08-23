using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaprTest.Domain
{
    public class OrderItem : EntityTenantBase
    {
        public string OrderId { get; set; }
        public string OrderNo { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductModel { get; set; }
        public decimal UnitPrice { get; set; }
        public int Number { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public AfterSaleStatus? AfterSaleStatus { get; set; }
    }
    /// <summary>
    /// 售后状态
    /// </summary>
    public enum AfterSaleStatus
    {
        /// <summary>
        /// 已发起等待同意
        /// </summary>
        WaitAgree=100,
        /// <summary>
        /// 等待发货
        /// </summary>
        WaitSend=200,
        /// <summary>
        /// 等待收货
        /// </summary>
        WaitReceipt=300,
        /// <summary>
        /// 等待退款
        /// </summary>
        WaitReturnAmount=400,
        /// <summary>
        /// 完成
        /// </summary>
        Complete=500,
        /// <summary>
        /// 拒绝
        /// </summary>
        Refuse=1000,
    }
    /// <summary>
    /// 售后类型
    /// </summary>
    public enum AfterSaleType
    {
        /// <summary>
        /// 退货退款
        /// </summary>
        ReturnProductAmount=100,
        /// <summary>
        /// 退款
        /// </summary>
        ReturnAmount=200,

    }
}
