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
using Microsoft.Extensions.Caching.Memory;

namespace Blog.Server.ServicesImpl
{
    public class UserServiceImpl : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public UserServiceImpl(UserRepository userRepository,IMapper mapper, IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<bool> IsExist(UserService_IsExistPara userService_IsExistPara)
        {
            return await _userRepository.Select.AnyAsync(it => it.UserEmail == userService_IsExistPara.UserEmail);
        }

        public async Task<bool> SignIn(UserService_SignInPara userService_SignInPara)
        {
            if (await _userRepository.Select.Where(it=>it.UserEmail== userService_SignInPara.UserEmail).FirstAsync(it=>it.UserPassword)!= _mapper.Map<User>(userService_SignInPara).UserPassword)
                return false;
            return true;
        }

        public async Task<bool> SignUp(UserService_SignUpPara userService_SignUpPara)
        {
            if (userService_SignUpPara.UserVerificationCode != _memoryCache.Get(userService_SignUpPara.UserEmail)?.ToString())//判断验证码是否有效
                return false;
            var willInsert = _mapper.Map<User>(userService_SignUpPara);
            await _userRepository.InsertAsync(willInsert);
            return true;
        }
    }
}
