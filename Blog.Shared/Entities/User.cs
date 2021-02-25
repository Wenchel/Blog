using System;
using System.Collections.Generic;
using System.Text;
using FreeSql.DataAnnotations;

namespace Blog.Shared.Entities
{
    [Table(Name = "User")]
    [Index("uk_useremail", "useremail", true)]
    public class User
    {
        [Column(IsPrimary = true)]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string UserAvatar { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public Group UserGroup { get; set; }
        public string UserIp { get; set; }

        [Column(ServerTime = DateTimeKind.Utc, CanUpdate = false)]
        public DateTime CreateUserTime { get; set; }
    }
    public enum Group
    {
        User,
        Administrator

    }
}
