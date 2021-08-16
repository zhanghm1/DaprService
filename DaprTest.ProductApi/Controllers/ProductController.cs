using Dapr;
using DaprTest.Domain;
using DaprTest.ProductApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ProductDbContext _productDbContext;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, ProductDbContext productDbContext)
        {
            _logger = logger;
            _productDbContext = productDbContext;
        }

        [HttpGet]
        public async Task<List<Product>>  Get()
        {
            return await _productDbContext.Products.Include(a=>a.Models).ToListAsync();
        }
        /// <summary>
        /// 减库存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Topic("pubsub", "newOrder")]// 必须要是正常的action 接口才有效
        [HttpPost]
        public async Task<IActionResult> newOrder(JianKuCunDto request)
        {
            _logger.LogInformation("pubsub:newOrder");
            var product = _productDbContext.Products.Include(a=>a.Models).Where(a => a.Id == request.ProductId).FirstOrDefault();
            if (product!=null)
            {
                var productModel = product.Models.Where(a => a.Model == request.Model).FirstOrDefault();
                if (productModel != null)
                {
                    productModel.Number -= request.Number;
                }
                await _productDbContext.SaveChangesAsync();
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
