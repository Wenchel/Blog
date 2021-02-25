using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntDesign;
using Blog.Shared.Parameters;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blog.Client.Shared.PageBases
{
    public class RegisterBase : ComponentBase
    {
        public string VerificationCodeButtonText { get; set; } = "获取验证码";
        public Button VerificationCodeButton { get; set; }
        public UserService_SignUpPara registerUser = new UserService_SignUpPara();

        public void OnFinish()
        {
            Console.WriteLine($"Success:");
        }

        public async Task SendVerificationCodeAsync()
        {
            VerificationCodeButton.Disabled = true;
            for (int i = 0; i < 120; i++)
            {
                await Task.Delay(1000);
                VerificationCodeButtonText = (119 - i).ToString();
                StateHasChanged();
            }
            VerificationCodeButtonText= "获取验证码";
            VerificationCodeButton.Disabled = false;

        }

    }
}
