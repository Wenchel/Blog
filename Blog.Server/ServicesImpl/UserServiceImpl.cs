using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Server.Repositories;
using Blog.Server.Services;
using Blog.Shared.Parameters;

namespace Blog.Server.ServicesImpl
{
    public class UserServiceImpl : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserServiceImpl(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsExist(UserService_IsExistPara userService_IsExistPara)
        {
            return await _userRepository.Select.AnyAsync(it => it.UserEmail == userService_IsExistPara.UserEmail);
        }

        public Task<bool> SignIn()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SignUp(UserService_SignUp userService_SignUp)
        {
            if (userService_SignUp.UserPassword!=userService_SignUp.UserRePassword)
            {
                return false;
            }
            var willInsert = new Shared.Entities.User() { };
            await _userRepository.InsertAsync(willInsert);

            return true;
        }
    }
}
