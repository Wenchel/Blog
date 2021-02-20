using System.Threading.Tasks;
using Blog.Client.Server.Models;
using Blog.Client.Server.Services;
using Microsoft.AspNetCore.Components;

namespace Blog.Client.Server.Pages.Profile
{
    public partial class Basic
    {
        private BasicProfileDataType _data = new BasicProfileDataType();

        [Inject] protected IProfileService ProfileService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _data = await ProfileService.GetBasicAsync();
        }
    }
}