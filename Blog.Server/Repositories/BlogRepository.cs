using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSql;

namespace Blog.Server.Repositories
{
    public class BlogRepository : BaseRepository<Shared.Entities.Blog, Guid>
    {
        public BlogRepository(IFreeSql fsql) : base(fsql, null, null)
        {
        }
    }
}
