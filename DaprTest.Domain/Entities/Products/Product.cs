using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaprTest.Domain
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public List<ProductModel> Models { get; set; }
    }
    /// <summary>
    /// 型号
    /// </summary>
    public class ProductModel : EntityBase
    {
        public int ProductId { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
    }
}
