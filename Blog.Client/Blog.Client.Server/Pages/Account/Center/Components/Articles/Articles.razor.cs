using System.Collections.Generic;
using Blog.Client.Server.Models;
using Microsoft.AspNetCore.Components;

namespace Blog.Client.Server.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}