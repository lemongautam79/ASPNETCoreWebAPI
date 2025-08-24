using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Models;
using ASPNETCoreWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
    [FromQuery] int page = 1,
    [FromQuery] int limit = 10,
    [FromQuery] string? search = null,
    [FromQuery] Role? role = null,
    [FromQuery] bool? isActive = null
)
        {
            var query = new UserQueryDto
            {
                Page = page,
                Limit = limit,
                Search = search,
                Role = role,
                IsActive = isActive
            };

            var (users, totalCount) = await _userService.GetAllAsync(query);

            var response = new
            {
                Data = users,
                TotalCount = totalCount,
                Page = page,
                Limit = limit,
                TotalPages = (int)Math.Ceiling((double)totalCount / limit)
            };

            return Ok(response);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _userService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
