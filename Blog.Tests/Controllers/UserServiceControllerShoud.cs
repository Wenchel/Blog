using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Server;
using Blog.Server.Controllers;
using Blog.Server.Repositories;
using Blog.Server.Services;
using Blog.Server.ServicesImpl;
using Blog.Shared.DataTransferObjects;
using Blog.Shared.Entities;
using Blog.Shared.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NETCore.Encrypt;
using Xunit;
using Xunit.Abstractions;

namespace Blog.Tests.Controllers
{
    public class UserServiceControllerShoud
    {
        private readonly UserServiceController _userServiceController;
        private readonly UserRepository _userRepository;
        private readonly ITestOutputHelper _output;
        private readonly JsonSerializerOptions _options;

        public UserServiceControllerShoud(ITestOutputHelper output)
        {
            var service = new ServiceProvider().ServiceConfig();
            _userRepository = service.GetService<UserRepository>();
            _userServiceController = new UserServiceController(service.GetService<IUserService>(), service.GetService<IMapper>());
            _output = output;

            _options = new JsonSerializerOptions();
            _options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All);
        }

        [Fact]
        public async Task SignInSucceedAsync()
        {
            await _userRepository.DeleteAsync(it=>it.UserEmail== "test@test.com");
            await _userRepository.InsertAsync(new User() { UserEmail="test@test.com",UserPassword= EncryptProvider.Sha256("testpassword"),UserNickname="test" });
            var signInPara = new UserService_SignInPara()
            {
                UserEmail = "test@test.com",
                UserPassword = "testpassword"
            };
            var result = await _userServiceController.SignInAsync(signInPara);
            var resultObj = result.Result as OkObjectResult;
            var resultVal = resultObj.Value as UserService_SignInDto;
            Assert.InRange((int)resultObj.StatusCode, 200, 299);
            Assert.True(resultVal.IsSuccess);
            _output.WriteLine(JsonSerializer.Serialize(resultVal, _options)) ;
        }

        [Fact]
        public async Task SignInFail()
        {
            var signInPara = new UserService_SignInPara()
            {
                UserEmail = "test@test.fail",
                UserPassword = "testpassword"
            };
            var result = await _userServiceController.SignInAsync(signInPara);
            var resultObj = result.Result as OkObjectResult;
            var resultVal = resultObj.Value as UserService_SignInDto;
            Assert.InRange((int)resultObj.StatusCode, 200, 299);
            Assert.False(resultVal.IsSuccess);
            _output.WriteLine(JsonSerializer.Serialize(resultVal, _options));
        }
    }
}
