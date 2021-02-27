using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.DataTransferObjects
{
    public class UserServiceDtoBase 
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class UserService_SignUpDto : UserServiceDtoBase { }
    public class UserService_SignInDto : UserServiceDtoBase { }
}
