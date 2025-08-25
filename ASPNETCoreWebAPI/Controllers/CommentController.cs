using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        //DI
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CommentQueryDto query)
        {
            var (comments, totalCount) = await _commentService.GetAllAsync(query);

            var response = new
            {
                Data = comments,
                TotalCount = totalCount,
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetPostsByUser(int postId)
        {
            var comments = await _commentService.GetCommentsByPostIdAsync(postId);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentDto request)
        {
            var comment = await _commentService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CommentDto request)
        {
            var comment = await _commentService.UpdateAsync(id, request);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _commentService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
