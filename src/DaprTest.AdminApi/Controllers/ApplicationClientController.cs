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
    public class ApplicationClientController : ControllerBase
    {
        private readonly ILogger<ApplicationClientController> _logger;

        public ApplicationClientController(ILogger<ApplicationClientController> logger)
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
