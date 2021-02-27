using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Server.Repositories;
using Blog.Server.Services;
using Blog.Shared.Entities;
using Blog.Shared.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserServiceController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserServiceController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpAsync([FromBody] UserService_SignUpPara userService_SignUpPara)
        {
            var result=await _userService.SignUp(userService_SignUpPara);
            return Ok(result);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync([FromBody] UserService_SignInPara userService_SignInPara)
        {
            var result = await _userService.SignIn(userService_SignInPara);
            return Ok(result);
        }
    }
}
