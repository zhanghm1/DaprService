using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaprTest.Domain
{
    public class Product : EntityTenantBase
    {
        public string Name { get; set; }
        public List<ProductModel> Models { get; set; }
    }
    /// <summary>
    /// 型号
    /// </summary>
    public class ProductModel : EntityTenantBase
    {
        public string ProductId { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
    }
    public class ProductStore
    {
        public string ProductId { get; set; }
        public string StoreId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        public int Number { get; set; }
    }
    public class ProductModelStore
    {
        public string ProductId { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public string ProductModelId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        public int Number { get; set; }
    }
}
