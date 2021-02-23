using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Shared.Entities;
using FreeSql;

namespace Blog.Server.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>
    {
        public UserRepository(IFreeSql fsql) : base(fsql, null, null)
        {
        }
    }
}
