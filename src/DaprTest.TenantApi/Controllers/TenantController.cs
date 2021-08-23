using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.TenantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : ControllerBase
    {
        
        private readonly ILogger<TenantController> _logger;

        public TenantController(ILogger<TenantController> logger)
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
