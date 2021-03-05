using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Blog.Server;
using Blog.Server.Services;
using Blog.Server.ServicesImpl;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Tests
{
    public class ServiceProvider
    {
        private ServiceCollection _service;
        public ServiceProvider()
        {
            _service = new ServiceCollection();
        }

        public Microsoft.Extensions.DependencyInjection.ServiceProvider ServiceConfig()
        {
            var basePath = ApplicationEnvironment.ApplicationBasePath;
            var serverDll = Path.Combine(basePath, "Blog.Server.dll");
            var freeSQL=new FreeSql.FreeSqlBuilder().UseConnectionString(FreeSql.DataType.MySql, "Data Source=127.0.0.1;Port=3306;User ID=root;Password=root; Initial Catalog=blogtest;Charset=utf8; SslMode=none;Min pool size=1")
                                                   .UseAutoSyncStructure(true)
                                                   .UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
                                                   .Build();
            _service.AddSingleton(freeSQL);
            _service.AddFreeRepository(null, Assembly.LoadFrom(serverDll));
            _service.AddMemoryCache();
            _service.AddAutoMapper(typeof(Startup));
            _service.AddScoped<IUserService, UserServiceImpl>();
            _service.AddScoped<IVerificationService, VerificationServiceImpl>();
            _service.AddScoped<IBlogService, BlogServiceImpl>();
            _service.AddScoped<IBlogClassificationService, BlogClassificationServiceImpl>();
            return _service.BuildServiceProvider();
        }
    }
}
