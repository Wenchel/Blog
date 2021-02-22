using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string UserAvatar { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public Group UserGroup { get; set; }
    }
    public enum Group
    { 
        Administrator,
        User
    }
}
