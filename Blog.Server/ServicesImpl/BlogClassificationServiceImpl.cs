using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Server.Repositories;
using Blog.Server.Services;
using Blog.Shared.Entities;
using Blog.Shared.Parameters;

namespace Blog.Server.ServicesImpl
{
    public class BlogClassificationServiceImpl : IBlogClassificationService
    {
        private readonly BlogClassificationRepository _blogClassificationRepository;

        public BlogClassificationServiceImpl(BlogClassificationRepository blogClassificationRepository)
        {
            _blogClassificationRepository = blogClassificationRepository;
        }


        public Task<BlogClassification> AddBlogClassificationAsync(BlogClassification entity)
        {
            var result=_blogClassificationRepository.InsertAsync(entity);
            return result;
        }

        public async Task<bool> DeleteBlogClassificationAsync(BlogClassification entity)
        {
            var result = await _blogClassificationRepository.DeleteAsync(entity);
            if (result != 1)
                return false;
            return true;
        }

        public async Task<IEnumerable<BlogClassification>> GetAllBlogClassificationAsync()
        {
            var result = await _blogClassificationRepository.Select.ToListAsync();
            return result;

        }

        public async Task<BlogClassification> GetOneBlogClassificationAsync(Guid key)
        {
            var result = await _blogClassificationRepository.Select.Where(it=>it.ClassificationId==key).FirstAsync();
            return result;
        }

        public async Task<bool> UpdateBlogClassificationAsync(BlogClassification entity)
        {
            entity.UpdateClassificationTime = DateTime.Now;
            var result = await _blogClassificationRepository.UpdateAsync(entity);
            if (result != 1)
                return false;
            return true;
        }
    }
}
