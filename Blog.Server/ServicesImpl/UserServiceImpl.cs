using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Server.Repositories;
using Blog.Server.Services;
using Blog.Shared.Entities;
using Blog.Shared.Parameters;

namespace Blog.Server.ServicesImpl
{
    public class UserServiceImpl : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServiceImpl(UserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> IsExist(UserService_IsExistPara userService_IsExistPara)
        {
            return await _userRepository.Select.AnyAsync(it => it.UserEmail == userService_IsExistPara.UserEmail);
        }

        public Task<bool> SignIn()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SignUp(UserService_SignUpPara userService_SignUpPara)
        {
            if (userService_SignUpPara.UserPassword != userService_SignUpPara.UserConfirmPassword)//判断前后密码是否一致
            {
                return false;
            }
            if (await IsExist(_mapper.Map<UserService_IsExistPara>(userService_SignUpPara)))//判断是否已注册
            {
                return false;
            }
            var willInsert = _mapper.Map<User>(userService_SignUpPara);
            await _userRepository.InsertAsync(willInsert);
            return true;
        }
    }
}
