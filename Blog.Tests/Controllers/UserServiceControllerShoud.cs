using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Blog.Server;
using Blog.Server.Controllers;
using Blog.Server.Services;
using Blog.Shared.Parameters;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Blog.Tests.Controllers
{
    public class UserServiceControllerShoud
    {
        private UserServiceController userServiceController;
        public UserServiceControllerShoud()
        {
            var _services =Program.CreateHostBuilder(new string[] { }).Build().Services;
            userServiceController = new UserServiceController(_services.GetRequiredService<IUserService>(), _services.GetRequiredService<IMapper>());
        }

        [Fact]
        public void SignUp()
        {
            var signInPara = new UserService_SignInPara()
            {
                UserEmail = "1106988466@qq.com",
                UserPassword = "Aaa192837"
            };
            var result =userServiceController.SignInAsync(signInPara);
        }
    }
}
