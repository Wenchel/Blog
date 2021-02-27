using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Server.Repositories;
using Blog.Server.Services;
using Blog.Shared.DataTransferObjects;
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
        private readonly IMapper _mapper;

        public UserServiceController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<UserService_SignUpDto>> SignUpAsync([FromBody] UserService_SignUpPara userService_SignUpPara)
        {
            if (await _userService.IsExist(_mapper.Map<UserService_IsExistPara>(userService_SignUpPara)))
                return Ok(new UserService_SignUpDto() { IsSuccess = false, Message = "该邮箱已经被注册！" });
            if (!await _userService.SignUp(userService_SignUpPara))
                return Ok(new UserService_SignUpDto() { IsSuccess = false, Message = "验证码错误或已失效！" });
            else
                return Ok(new UserService_SignUpDto() { IsSuccess = true, Message = "注册成功！" });
        }
        [HttpPost("SignIn")]
        public async Task<ActionResult<UserService_SignInDto>> SignInAsync([FromBody] UserService_SignInPara userService_SignInPara)
        {
            if (!await _userService.SignIn(userService_SignInPara))
                return Ok(new UserService_SignInDto() { IsSuccess = false, Message = "账号或密码错误！" });
            return Ok(new UserService_SignInDto() { IsSuccess = true, Message = "登录成功！" });
        }
    }
}
