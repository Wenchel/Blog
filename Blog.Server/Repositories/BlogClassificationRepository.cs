using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Shared.Entities;
using FreeSql;

namespace Blog.Server.Repositories
{
    public class BlogClassificationRepository : BaseRepository<BlogClassification, Guid>
    {
        public BlogClassificationRepository(IFreeSql fsql) : base(fsql, null, null)
        {
        }
    }
}
