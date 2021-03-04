using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Server.Repositories;
using Blog.Server.Services;

namespace Blog.Server.ServicesImpl
{
    public class BlogServiceImpl : IBlogService
    {
        //private readonly BlogClassificationRepository _blogClassificationRepository;
        //private readonly BlogRepository _blogRepository;
        //private readonly IFreeSql freeSql;

        //public BlogServiceImpl(BlogClassificationRepository blogClassificationRepository,BlogRepository blogRepository,IFreeSql freeSql)
        //{
        //    _blogClassificationRepository = blogClassificationRepository;
        //    _blogRepository = blogRepository;
        //    this.freeSql = freeSql;
        //}

        //public Task GetBlogs()
        //{
        //    var a= freeSql.Select<Blog.Shared.Entities.Blog>().ToList();
        //    var r = _blogRepository.Select.Include(i=>i.Classification).Where(it => it.Classification.ClassificationName == "C#").ToListAsync();
        //    var s = _blogClassificationRepository.Select.IncludeMany(i=>i.Blogs).Where(it => it.ClassificationName == "C#").ToListAsync();
        //    return null;
        //}
        public Task AddBlogClassification()
        {
            throw new NotImplementedException();
        }
    }
}
