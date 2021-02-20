using Microsoft.AspNetCore.Components;

namespace Blog.Client.Wasm.Pages.Account.Center
{
    public partial class AvatarList
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}