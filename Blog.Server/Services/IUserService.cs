using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Shared.DataTransferObjects;
using Blog.Shared.Parameters;

namespace Blog.Server.Services
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns>登录是否成功</returns>
        Task<bool> SignIn();

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns>注册是否成功</returns>
        Task<UserService_SignUpDto> SignUp(UserService_SignUpPara userService_SignUp);

        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <returns>用户是否存在</returns>
        Task<bool> IsExist(UserService_IsExistPara userService_IsExistPara);
    }
}
