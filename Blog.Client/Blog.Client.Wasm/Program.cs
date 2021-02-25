using AntDesign.Pro.Layout;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Blog.Client.Shared;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Blog.Shared.Models;

namespace Blog.Client.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress+"haha/") });
            builder.Services.AddAntDesign();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddHttpClient("UserService", config =>
            {
                config.BaseAddress = new Uri("https://localhost:5001/api/UserService/");
            });
            builder.Services.AddHttpClient("VerificationService", config =>
            {
                config.BaseAddress = new Uri("https://localhost:5001/api/VerificationService/");
            });
            

            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
            var hostUrl = builder.HostEnvironment.BaseAddress;
            builder.Services.AddSingleton<HostAddress>(new HostAddress() { Address= hostUrl });
            await builder.Build().RunAsync();
        }
    }
}