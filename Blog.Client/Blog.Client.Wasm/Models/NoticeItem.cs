using AntDesign.Pro.Layout;

namespace Blog.Client.Wasm.Models
{
    public class NoticeItem : NoticeIconData
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}