using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Shared.Entities;
using Blog.Shared.Parameters;

namespace Blog.Server.Services
{
    public interface IBlogClassificationService
    {
        Task<BlogClassification> GetOneBlogClassificationAsync(Guid key);
        Task<IEnumerable<BlogClassification>> GetAllBlogClassificationAsync();
        Task<BlogClassification> AddBlogClassificationAsync(BlogClassification entity);
        Task<bool> DeleteBlogClassificationAsync(BlogClassification entity);
        Task<bool> UpdateBlogClassificationAsync(BlogClassification entity);
    }
}
