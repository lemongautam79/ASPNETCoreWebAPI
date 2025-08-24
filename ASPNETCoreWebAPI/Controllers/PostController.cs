using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        // DI
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PostQueryDto query)
        {
            var (posts, totalCount) = await _postService.GetAllAsync(query);

            var response = new
            {
                Data = posts,
                TotalCount = totalCount,
                Page = query.Page,
                Limit = query.Limit,
                TotalPages = (int)Math.Ceiling((double)totalCount / query.Limit)
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPostsByUser(Guid userId)
        {
            var posts = await _postService.GetPostsByUserIdAsync(userId);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostDto request)
        {
            var post = await _postService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PostDto request)
        {
            var post = await _postService.UpdateAsync(id, request);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _postService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
