using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AntDesign;
using Blog.Shared.DataTransferObjects;
using Blog.Shared.Parameters;
using Microsoft.AspNetCore.Components;

namespace Blog.Client.Shared.PageBases
{
    public class SignInBase: ComponentBase
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public MessageService Message { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        public UserService_SignInPara SignInUser { get; set; } = new UserService_SignInPara();
        public bool Loading { get; set; } = false;
        public async Task OnFinishAsync()
        {
            var client = ClientFactory.CreateClient("UserService");
            var messageConfig = new MessageConfig()
            {
                Content = "正在登录...",
                Duration = 1000,
                Key= "SignIn"
            };
            try
            {
                Loading = true;
                _ = Message.Loading(messageConfig);
                var response = await client.PostAsJsonAsync("SignIn", SignInUser);
                var result = await response.Content.ReadFromJsonAsync<UserService_SignInDto>();
                if (result.IsSuccess)
                {
                    Loading = false;
                    messageConfig.Content = $"登录成功：{result.Message}";
                    messageConfig.Duration = 1;
                    await Message.Success(messageConfig).ContinueWith(re=> { Navigation.NavigateTo(""); });            
                }
                else
                {
                    Loading = false;
                    messageConfig.Content = $"登录失败：{result.Message}";
                    messageConfig.Duration = 1;
                    _ = Message.Error(messageConfig);
                }
            }
            catch (Exception e)
            {
                Loading = false;
                messageConfig.Content = $"登录出错：{e.Message}";
                messageConfig.Duration = 3;
                _ = Message.Error(messageConfig);
            }
        }
    }
}
