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
            try
            {
                Loading = true;
                var response = await client.PostAsJsonAsync("SignIn", SignInUser);
                var result = await response.Content.ReadFromJsonAsync<UserService_SignInDto>();
                if (result.IsSuccess)
                {
                    _ = Message.Success($"{result.Message}");
                    //_visible = true;
                    //for (int i = 0; i < 3; i++)
                    //{
                    //    await Task.Delay(1000);
                    //    //SuccessWait = $"{2 - i}秒后跳转到登录界面";
                    //    StateHasChanged();
                    //}
                    //await Task.Delay(200);
                    ////_visible = false;
                    //await Task.Delay(200);
                    Loading = false;
                    //Navigation.NavigateTo("/sign-in");
                }
                else
                {
                    _ = Message.Error($"{result.Message}");
                    Loading = false;
                }
            }
            catch (Exception e)
            {
                _ = Message.Error($"{e.Message}");
                Loading = false;
            }
        }
    }
}
