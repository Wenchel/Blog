using System;
using System.Collections.Generic;
using System.Text;
using FreeSql.DataAnnotations;

namespace Blog.Shared.Entities
{
    /// <summary>
    /// 博客分类表
    /// </summary>
    [Table(Name = "BlogClassification")]
    [Index("uk_classificationname", "classificationname", true)]//唯一键
    public class BlogClassification
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        [Column(IsPrimary = true)]//主键
        public Guid ClassificationId { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ClassificationName { get; set; }
        /// <summary>
        /// 分类下的博客
        /// </summary>
        [Navigate(nameof(Blog.ClassificationId))]
        public List<Blog> Blogs { get; set; }
    }
}
