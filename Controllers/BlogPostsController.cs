using blogging_platform_api.Models;
using blogging_platform_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogging_platform_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        IBlogPostService _blogPostService { get; set; }

        public BlogPostsController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        { 
            var result = _blogPostService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _blogPostService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BlogPostUpsertDto dto) 
        { 
            var result = _blogPostService.Create(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BlogPostUpsertDto dto)
        {
            var result = _blogPostService.Update(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        { 
            _blogPostService.Delete(id);
            return Ok();
        }
    }
}
