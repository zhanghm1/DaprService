using DaprTest.Domain.Entities.Members;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.MemberApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<Member> Get()
        {
            return new Member();
        }
    }
}
