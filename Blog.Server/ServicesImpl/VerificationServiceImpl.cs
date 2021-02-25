using System;
using System.Threading.Tasks;
using Blog.Server.Services;
using Blog.Shared.DataTransferObjects;
using Blog.Shared.Parameters;
using FluentEmail.Core;
using Microsoft.Extensions.Caching.Memory;

namespace Blog.Server.ServicesImpl
{
    public class VerificationServiceImpl : IVerificationService
    {
        private readonly IFluentEmail _fluentEmail;
        private readonly IMemoryCache _memoryCache;

        public VerificationServiceImpl(IFluentEmail fluentEmail,IMemoryCache memoryCache)
        {
            _fluentEmail = fluentEmail;
            _memoryCache= memoryCache;
        }

        public async Task<VerificationService_GetVerificationCodeDto> GetVerificationCode(VerificationService_GetVerificationCodePara verificationService_GetVerificationCodePara)
        {
            var code = Guid.NewGuid().ToString().Split("-")[0].ToUpper();
            var imgUrl = verificationService_GetVerificationCodePara.ClientAdress+"logo.png";
            var content = $@"<div align='center'><img src='{imgUrl}' height='150px'></div>
                             <h3 align='left'>Wenchel Blog用户，您好！</h3>
                             <p>您的验证码为：</p><br/>
                             <h1 align='center'>{code}</h1><br/>
                             <p>您会收到这封自动产生的邮件，是由于有人试图通过此邮箱注册成为Wenchel Blog用户。Wenchel Blog验证码是完成注册所必需的。没有人能够不访问这封电子邮件就能注册成功。</p>
                             <p>如果您未曾尝试注册，很抱歉给您带来了打扰。</p><br/><br/>
                             祝您生活愉快，<br/>Wenchel";
            try
            {
                var result = await _fluentEmail.To(verificationService_GetVerificationCodePara.EmailAddress).Subject("Wenchel Blog 验证码").Body(content, true).SendAsync();
                if (result.Successful)
                {
                    _memoryCache.Set(verificationService_GetVerificationCodePara.EmailAddress, code, TimeSpan.FromMinutes(5));
                    return new VerificationService_GetVerificationCodeDto() { IsSuccess=true, Message="获取验证码成功！" };
                }
                else
                {
                    return new VerificationService_GetVerificationCodeDto() { IsSuccess = false, Message = "获取验证码失败！" };
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("DT:SPM"))
                {
                    return new VerificationService_GetVerificationCodeDto() { IsSuccess = false, Message = "DT:SPM ,请稍后再试 邮件正文带有垃圾邮件特征或发送环境缺乏规范性，被临时拒收。请保持邮件队列，两分钟后重投邮件。需调整邮件内容或优化发送环境！" };
                }
                return new VerificationService_GetVerificationCodeDto() { IsSuccess = false, Message = e.Message }; 
            }
        }
    }
}