using Dapr;
using DaprTest.Domain;
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
            if (Products == null)
            {
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
        [Topic("pubsub", "newOrder")]
        //[HttpPost]
        public async Task<IActionResult> Post(JianKuCunDto request)
        {
            _logger.LogInformation("pubsub:newOrder");
            var productModel = Products.Where(a => a.Id == request.ProductId).FirstOrDefault()?.Models.Where(a => a.Model == request.Model).FirstOrDefault();
            if (productModel!=null)
            {
                productModel.Number -= request.Number;
            }
            
            return Ok();
        }
    }

    public class JianKuCunDto
    { 
        public int ProductId { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }
    }
}
