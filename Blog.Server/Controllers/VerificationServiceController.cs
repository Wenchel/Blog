using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Server.Services;
using Blog.Shared.Parameters;
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
        public async Task<IActionResult> GetVerificationCodeAsync([FromBody] VerificationService_GetVerificationCodePara verificationService_GetVerificationCodePara)
        {
            var result = await _verificationService.GetVerificationCode(verificationService_GetVerificationCodePara);
            return Ok(result);
        }
    }
}
