using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationServiceController : ControllerBase
    {
        private readonly IVerificationService _verificationService;

        public VerificationServiceController(IVerificationService verificationService)
        {
            _verificationService = verificationService;
        }
        [HttpPost]
        public async Task<IActionResult> GetVerificationCodeAsync([FromBody] string emailAddress)
        {
            var result = await _verificationService.GetVerificationCode(emailAddress);
            return Ok(result);
        }
    }
}
