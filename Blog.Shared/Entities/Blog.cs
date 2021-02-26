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
        /// <summary>
        /// 博客分类ID
        /// </summary>
        public Guid ClassificationId { get; set; }
        /// <summary>
        /// 博客所在分类
        /// </summary>
        [Navigate(nameof(ClassificationId))]
        public BlogClassification Classification { get; set; }

        [Column(StringLength = -1)]//映射为text类型
        public string BlogContent { get; set; }

        /// <summary>
        /// 创建博客时间
        /// </summary>
        [Column(ServerTime = DateTimeKind.Utc, CanUpdate = false)]
        public DateTime CreateBlogTime { get; set; }

        /// <summary>
        /// 创建更新时间
        /// </summary>
        [Column(ServerTime = DateTimeKind.Utc)]
        public DateTime UpdateBlogTime { get; set; }
    }
}
