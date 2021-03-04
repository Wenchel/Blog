using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Shared.Parameters
{
    public class BlogClassificationServiceParaBase
    {
        [Display(Name = "分类名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [MaxLength(10, ErrorMessage = "{0}长度不能超过{1}")]
        public string ClassificationName { get; set; }
    }
    public class BlogClassificationService_AddPara : BlogClassificationServiceParaBase { }
    public class BlogClassificationService_UpdatePara : BlogClassificationServiceParaBase { }

}
