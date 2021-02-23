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
    [Route("[controller]")]
    public class UserServiceController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserServiceController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] UserService_SignUpPara userService_SignUpPara)
        {
            var result=await _userService.SignUp(userService_SignUpPara);
            return Ok(result);
        }
    }
}
