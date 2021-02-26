using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Server.Services
{
    public interface IBlogService
    {
        Task GetBlogs();
    }
}
