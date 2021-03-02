using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AntDesign;
using Blog.Shared.DataTransferObjects;
using Blog.Shared.Parameters;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;

namespace Blog.Client.Shared.PageBases
{
    public class SignUpBase : ComponentBase
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public MessageService Message { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        public string VerificationCodeButtonText { get; set; } = "获取验证码";
        public Button VerificationCodeButton { get; set; }
        public UserService_SignUpPara SignUpUser { get; set; } = new UserService_SignUpPara();
        public bool Loading { get; set; }=false;



        public async Task OnFinishAsync()
        {
            var client = ClientFactory.CreateClient("UserService");
            var messageConfig = new MessageConfig()
            {
                Content = "正在注册...",
                Duration = 1000,
                Key = "SignUp"
            };
            try
            {
                Loading = true;
                _ = Message.Loading(messageConfig);
                var response = await client.PostAsJsonAsync("SignUp", SignUpUser);
                var result = await response.Content.ReadFromJsonAsync<UserService_SignUpDto>();
                if (result.IsSuccess)
                {
                    Loading = false;
                    messageConfig.Content = $"注册成功：{result.Message}";
                    messageConfig.Duration = 1;
                    await Message.Success(messageConfig).ContinueWith(re => { Navigation.NavigateTo("/sign-in"); });
                }
                else
                {
                    Loading = false;
                    messageConfig.Content = $"注册失败：{result.Message}";
                    messageConfig.Duration = 1;
                    _ = Message.Error(messageConfig);
                }
            }
            catch (Exception e)
            {
                Loading = false;
                messageConfig.Content = $"注册出错：{e.Message}";
                messageConfig.Duration = 3;
                _ = Message.Error(messageConfig);
            }
        }

        public async Task SendVerificationCodeAsync()
        {
            var para = new VerificationService_GetVerificationCodePara() { EmailAddress= SignUpUser.UserEmail };
            var validateResults = new List<ValidationResult>();
            Validator.TryValidateObject(para, new ValidationContext(para), validateResults, true);
            if (validateResults.Count>0)
            {
                foreach (var error in validateResults)
                {
                    _ = Message.Error($"{error.ErrorMessage}");
                }
                return;
            }
            var client = ClientFactory.CreateClient("VerificationService");
            var messageConfig = new MessageConfig()
            {
                Content = "正在发送验证码...",
                Duration = 1000,
                Key = "Code"
            };
            try
            {
                _ = Message.Loading(messageConfig);
                var response = await client.PostAsJsonAsync("", para);
                var result = await response.Content.ReadFromJsonAsync<VerificationService_GetVerificationCodeDto>();
                if (result.IsSuccess)
                {
                    messageConfig.Content = $"获取成功：{result.Message}";
                    messageConfig.Duration = 1;
                    _ = Message.Success(messageConfig);

                    VerificationCodeButton.Disabled = true;
                    for (int i = 0; i < 120; i++)
                    {
                        await Task.Delay(1000);
                        VerificationCodeButtonText = (119 - i).ToString()+"后重试";
                        StateHasChanged();
                    }
                    VerificationCodeButtonText = "获取验证码";
                    VerificationCodeButton.Disabled = false;

                }
                else
                {
                    messageConfig.Content = $"获取失败：{result.Message}";
                    messageConfig.Duration = 1;
                    _ = Message.Error(messageConfig);
                }
            }
            catch (Exception e)
            {
                messageConfig.Content = $"获取出错：{e.Message}";
                messageConfig.Duration = 3;
                _ = Message.Error(messageConfig);
            }
            



            

        }

    }
}
