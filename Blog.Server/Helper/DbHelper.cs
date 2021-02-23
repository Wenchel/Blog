using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Blog.Shared.Entities;
using FreeSql.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace Blog.Server.Helper
{
    public class DbHelper
    {
        private static IConfiguration _configuration;
        public DbHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IFreeSql FreeSql => new FreeSql.FreeSqlBuilder().UseConnectionString((FreeSql.DataType)Enum.Parse(typeof(FreeSql.DataType), _configuration.GetConnectionString("DbType")), _configuration.GetConnectionString("ConnectionString"))
                                                   .UseAutoSyncStructure(true) //自动同步实体结构到数据库
                                                   .UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
                                                   .Build();
        public void SyncToDateBase()
        {
            FreeSql.CodeFirst.SyncStructure(GetTypesByTableAttribute());
        }

        private Type[] GetTypesByTableAttribute()
        {
            List<Type> tableAssembies = new List<Type>();
            foreach (Type type in Assembly.GetAssembly(typeof(User)).GetExportedTypes())
                foreach (Attribute attribute in type.GetCustomAttributes())
                    if (attribute is TableAttribute tableAttribute)
                        if (tableAttribute.DisableSyncStructure == false)
                            tableAssembies.Add(type);
            return tableAssembies.ToArray();
        }


    }
}
