using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.PayApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayController : ControllerBase
    {
        private readonly ILogger<PayController> _logger;

        public PayController(ILogger<PayController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "";
        }
    }
}
