using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Shared.Parameters
{
    public class UserServiceParaBase
    {
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "{0}是必填项")]
        [EmailAddress(ErrorMessage ="{0}是不合法的")]
        public string UserEmail { get; set; }
    }

    public class UserService_IsExistPara : UserServiceParaBase { }

    public class UserService_SignUpPara : UserServiceParaBase 
    {
        
        [Display(Name ="昵称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [MaxLength(10, ErrorMessage = "{0}长度不能超过{1}")]
        public string UserNickname { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0}是必填项")]
        [MinLength(8,ErrorMessage ="{0}至少8位")]
        public string UserPassword { get; set; }

        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "{0}是必填项")]
        [Compare("UserPassword",ErrorMessage ="{0}和{1}不一致")]
        public string UserRePassword { get; set; }
    }
}
