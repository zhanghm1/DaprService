using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            Products = new List<Product>() {
                new Product(){
                    Id=1,
                    Name="iPhone X",
                    Models=new List<ProductModel>(){
                        new ProductModel(){
                            Id=1,
                            ProductId=1,
                            Model="64G",
                            Number=100
                        },
                        new ProductModel(){
                            Id=1,
                            ProductId=1,
                            Model="128G",
                            Number=100
                        },
                    }
                },
                new Product(){
                    Id=2,
                    Name="iPhone XR",
                    Models=new List<ProductModel>(){
                        new ProductModel(){
                            Id=1,
                            ProductId=1,
                            Model="64G",
                            Number=100
                        },
                        new ProductModel(){
                            Id=1,
                            ProductId=1,
                            Model="128G",
                            Number=100
                        },
                    }
                },
            };
        }

        [HttpGet]
        public async Task<List<Product>>  Get()
        {
            return Products;
        }
        /// <summary>
        /// 减库存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Topic("order", "newOrder")]
        [HttpPut]
        public async Task<IActionResult> Put(JianKuCunDto request)
        {
            var productModel = Products.Where(a => a.Id == request.ProductId)?.FirstOrDefault().Models.Where(a => a.Model == request.Model)?.FirstOrDefault();
            productModel.Number -= request.Number;
            return Ok();
        }
    }
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
    }
    public class JianKuCunDto
    { 
        public int ProductId { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }
    }
}
