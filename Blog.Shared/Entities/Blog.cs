using System;
using System.Collections.Generic;
using System.Text;
using FreeSql.DataAnnotations;

namespace Blog.Shared.Entities
{
    [Table(Name = "Blog")]
    public class Blog
    {
        /// <summary>
        /// 博客ID
        /// </summary>
        [Column(IsPrimary = true)]//主键
        public Guid BlogId { get; set; }
        /// <summary>
        /// 博客标题
        /// </summary>
        public string BlogTitle { get; set; }

        public Guid ClassificationId { get; set; }

        [Navigate(nameof(ClassificationId))]
        public BlogClassification Classification { get; set; }
    }
}
