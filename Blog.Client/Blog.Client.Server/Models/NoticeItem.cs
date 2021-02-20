using AntDesign.Pro.Layout;

namespace Blog.Client.Server.Models
{
    public class NoticeItem : NoticeIconData
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}