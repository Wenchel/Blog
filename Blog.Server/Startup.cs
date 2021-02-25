using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Blog.Server.Helper;
using Blog.Server.Services;
using Blog.Server.ServicesImpl;
using Blog.Shared.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Blog.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog.Server", Version = "v1" });
            });
            #region 注入FreeSQL
            var dbHelper = new DbHelper(Configuration);
            var fsql = dbHelper.FreeSql;//得到FreeSQL实例
            services.AddSingleton(fsql);//依赖注入
            dbHelper.SyncToDateBase();//同步实体到数据库
            services.AddFreeRepository(null, this.GetType().Assembly);
            #endregion
            #region 注入AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion
            #region 注入邮件发送服务
            services.AddFluentEmail("WenchelChow@yeah.net").AddSmtpSender(new SmtpClient
            {
                Host = "smtp.yeah.net",//smtp服务器地址
                UseDefaultCredentials = false,//配合EnableSsl = true
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("WenchelChow", "GQWPUJBKPWUYYHSG"),//用户名和授权码
                EnableSsl = true//开启SSL
            });
            #endregion
            #region 注入缓存
            services.AddMemoryCache();
            #endregion
            #region 注入服务
            services.AddScoped<IUserService, UserServiceImpl>();
            services.AddScoped<IVerificationService, VerificationServiceImpl>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog.Server v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
