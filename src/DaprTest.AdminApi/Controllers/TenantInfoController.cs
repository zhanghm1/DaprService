using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.AdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantInfoController : ControllerBase
    {
        private readonly ILogger<TenantInfoController> _logger;

        public TenantInfoController(ILogger<TenantInfoController> logger)
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
