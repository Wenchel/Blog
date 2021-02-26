using System;
using System.Collections.Generic;
using System.Text;
using FreeSql.DataAnnotations;

namespace Blog.Shared.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table(Name = "User")]
    [Index("uk_useremail", "useremail", true)]//唯一键
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column(IsPrimary = true)]//主键
        public Guid UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNickname { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// 用户邮箱地址
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// 用户手机
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>
        /// 用户分组
        /// </summary>
        public Group UserGroup { get; set; }

        /// <summary>
        /// 用户注册、登录IP
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 创建用户时间
        /// </summary>
        [Column(ServerTime = DateTimeKind.Utc, CanUpdate = false)]
        public DateTime CreateUserTime { get; set; }
    }

    /// <summary>
    /// 用户组
    /// </summary>
    public enum Group
    {
        User,
        Administrator
    }
}
