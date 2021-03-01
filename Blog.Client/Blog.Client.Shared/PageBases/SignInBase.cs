using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Shared.Parameters;
using Microsoft.AspNetCore.Components;

namespace Blog.Client.Shared.PageBases
{
    public class SignInBase: ComponentBase
    {
        public UserService_SignInPara SignInUser { get; set; } = new UserService_SignInPara();
    }
}
