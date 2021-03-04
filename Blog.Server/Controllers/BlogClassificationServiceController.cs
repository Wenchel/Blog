using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Server.Services;
using Blog.Shared.DataTransferObjects;
using Blog.Shared.Entities;
using Blog.Shared.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogClassificationServiceController : ControllerBase
    {
        private readonly IBlogClassificationService _blogClassificationService;
        private readonly IMapper _mapper;

        public BlogClassificationServiceController(IBlogClassificationService blogClassificationService,IMapper mapper)
        {
            _blogClassificationService = blogClassificationService;
            _mapper = mapper;
        }

        [HttpGet("{blogClassificationId}",Name = nameof(GetOneBlogClassificationAsync))]
        public async  Task<IActionResult> GetOneBlogClassificationAsync([FromRoute]Guid blogClassificationId)
        {
            var result=await _blogClassificationService.GetOneBlogClassificationAsync(blogClassificationId);
            if (result == null)
                return NotFound();
            var resultDto = _mapper.Map<BlogClassificationService_GetDto>(result);
            return Ok(resultDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogClassificationAsync()
        {
            var result = await _blogClassificationService.GetAllBlogClassificationAsync();
            var resultDto = _mapper.Map<IEnumerable<BlogClassificationService_GetDto>>(result);
            return Ok(resultDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddBlogClassificationAsync([FromBody] BlogClassificationService_AddPara para)
        {
            var entity = _mapper.Map<BlogClassification>(para);
            var result = await _blogClassificationService.AddBlogClassificationAsync(entity);
            var resultDto= _mapper.Map<BlogClassificationService_AddDto>(result);
            return CreatedAtRoute(nameof(GetOneBlogClassificationAsync), new { BlogClassificationId= resultDto.ClassificationId } , resultDto);
        }

        [HttpDelete("{blogClassificationId}")]
        public async Task<IActionResult> DeleteBlogClassificationAsync([FromRoute] Guid blogClassificationId)
        {
            var entity = await _blogClassificationService.GetOneBlogClassificationAsync(blogClassificationId);
            if (entity==null)
                return NotFound();
            var result=await _blogClassificationService.DeleteBlogClassificationAsync(entity);
            if (!result)
                return Problem();
            return NoContent();
        }

        [HttpPut("{blogClassificationId}")]
        public async Task<IActionResult> UpdateBlogClassificationAsync([FromRoute] Guid blogClassificationId, [FromBody] BlogClassificationService_UpdatePara para)
        {
            var entity= await _blogClassificationService.GetOneBlogClassificationAsync(blogClassificationId);
            if (entity == null)
                return NotFound();
            _mapper.Map(para, entity);
            var result=await _blogClassificationService.UpdateBlogClassificationAsync(entity);
            if (!result)
                return Problem();
            var resultDto = _mapper.Map<BlogClassificationService_UpdateDto>(entity);
            return Ok(resultDto);
        }

    }
}
