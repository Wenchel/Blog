using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Blog.Server.Services;
using FluentEmail.Core;
using FluentEmail.Smtp;

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
            var result = await _fluentEmail.To(emailAddress).Subject("邮件标题").Body("邮件123内容").SendAsync();
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