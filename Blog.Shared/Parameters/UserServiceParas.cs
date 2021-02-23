using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.Parameters
{
    public class UserServiceParaBase
    {
        public string UserEmail { get; set; }
    }

    public class UserService_IsExistPara : UserServiceParaBase { }

    public class UserService_SignUp : UserServiceParaBase {
        public string UserNickname { get; set; }
        public string UserPassword { get; set; }
        public string UserRePassword { get; set; }
    }
}
