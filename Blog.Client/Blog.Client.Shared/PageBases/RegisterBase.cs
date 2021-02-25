﻿using System;
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
using Microsoft.AspNetCore.Http;

namespace Blog.Client.Shared.PageBases
{
    public class RegisterBase : ComponentBase
    {
        [Inject]
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        [Inject]
        public MessageService Message { get; set; }
        public string VerificationCodeButtonText { get; set; } = "获取验证码";
        public Button VerificationCodeButton { get; set; }
        public UserService_SignUpPara RegisterUser { get; set; } = new UserService_SignUpPara();
        

        public void OnFinish()
        {
            Console.WriteLine($"Success");
        }

        public async Task SendVerificationCodeAsync()
        {
            var hostUrl = $"{HttpContextAccessor.HttpContext.Request.Scheme}://{HttpContextAccessor.HttpContext.Request.Host.Value}";
            var para = new VerificationService_GetVerificationCodePara() { ClientAdress= hostUrl, EmailAddress= RegisterUser.UserEmail };
            var validateResults = new List<ValidationResult>();
            Validator.TryValidateObject(para, new ValidationContext(para), validateResults, true);
            if (validateResults.Count>0)
            {
                foreach (var error in validateResults)
                {
                    await Message.Error($"{error.ErrorMessage}");
                }
                return;
            }
            var client = ClientFactory.CreateClient("VerificationService");
            try
            {
                var response = await client.PostAsJsonAsync("", para);
                var result = await response.Content.ReadFromJsonAsync<VerificationService_GetVerificationCodeDto>();
                if (result.IsSuccess)
                {
                    await Message.Success($"{result.Message}");

                    VerificationCodeButton.Disabled = true;
                    for (int i = 0; i < 120; i++)
                    {
                        await Task.Delay(1000);
                        VerificationCodeButtonText = (119 - i).ToString();
                        StateHasChanged();
                    }
                    VerificationCodeButtonText = "获取验证码";
                    VerificationCodeButton.Disabled = false;

                }
                else
                {
                    await Message.Error($"{result.Message}");
                }
            }
            catch (Exception e)
            {
                await Message.Error($"{e.Message}");
            }
            



            

        }

    }
}
