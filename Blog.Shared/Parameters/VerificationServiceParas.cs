using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Shared.Parameters
{
    public class VerificationService_GetVerificationCodePara
    {
        [Display(Name = "客户端地址")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string ClientAdress { get; set; }

        [Display(Name = "邮箱地址")]
        [Required(ErrorMessage = "{0}是必填项")]
        [EmailAddress(ErrorMessage = "{0}不合法")]
        public string EmailAddress { get; set; }
    }
}
