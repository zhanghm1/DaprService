using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DaprTest.OrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly DaprClient _daprClient;
        public OrderController(ILogger<OrderController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpGet]
        public async Task<IEnumerable<string>>  Get()
        {
            await _daprClient.PublishEventAsync("order", "newOrder", new JianKuCunDto
            {
                ProductId = 1,
                Model = "32G",
                Number = 1

            });

            return await _daprClient.InvokeMethodAsync<IEnumerable<string>>(HttpMethod.Get,"productapi", "Product");
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddOrderDto addOrder)
        {
            await _daprClient.PublishEventAsync("order", "newOrder", new JianKuCunDto
            {
                ProductId = addOrder.ProductId,
                Model = addOrder.Model,
                Number = addOrder.Number

            });
            return Ok();
        }
    }
    public class AddOrderDto
    {
        public int MemberId { get; set; }
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
