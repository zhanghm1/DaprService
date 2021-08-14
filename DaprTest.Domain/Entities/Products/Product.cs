using System;
using System.Collections.Generic;

namespace DaprTest.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductModel> Models { get; set; }
    }
    /// <summary>
    /// 型号
    /// </summary>
    public class ProductModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
