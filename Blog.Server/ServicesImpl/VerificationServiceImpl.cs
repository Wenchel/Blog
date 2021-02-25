using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Blog.Server.Services;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace Blog.Server.ServicesImpl
{
    public class VerificationServiceImpl : IVerificationService
    {
        private readonly IFluentEmail _fluentEmail;

        public VerificationServiceImpl(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task<bool> GetVerificationCode(string emailAddress)
        {
            var code = Guid.NewGuid().ToString().Split("-")[0].ToUpper();
            var content = $@"<div align='center'>
    <img src='./logo.png' height='150px'>
</div>
<h3 align='left'>Wenchel Blog用户，您好！</h3>
<p>您的验证码为：</p>
<br/>
<h1 align='center'>{code}</h1>
<br/>
<p>
    您会收到这封自动产生的邮件，是由于有人试图通过此邮箱注册成为Wenchel Blog用户。Wenchel Blog验证码是完成注册所必需的。没有人能够不访问这封电子邮件就能注册成功。
</p>
<p>
    如果您未曾尝试注册，很抱歉给您带来了打扰。
</p>
<br/>
<br/>
祝您生活愉快，<br/>Wenchel";
            var result = await _fluentEmail.To(emailAddress).Subject("Wenchel验证码").Body(content,true).SendAsync();
            if (result.Successful)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}