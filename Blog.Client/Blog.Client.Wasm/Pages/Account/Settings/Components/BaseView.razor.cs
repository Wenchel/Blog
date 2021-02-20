using System.Threading.Tasks;
using Blog.Client.Wasm.Models;
using Blog.Client.Wasm.Services;
using Microsoft.AspNetCore.Components;

namespace Blog.Client.Wasm.Pages.Account.Settings
{
    public partial class BaseView
    {
        private CurrentUser _currentUser = new CurrentUser();

        [Inject] protected IUserService UserService { get; set; }

        private void HandleFinish()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _currentUser = await UserService.GetCurrentUserAsync();
        }
    }
}