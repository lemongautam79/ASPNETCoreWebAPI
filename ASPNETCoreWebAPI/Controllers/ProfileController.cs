using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProfileDto dto)
        {
            try
            {
                var profile = await _profileService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = profile.Id }, profile);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profile = await _profileService.GetByIdAsync(id);
            if (profile == null) return NotFound();
            return Ok(profile);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profiles = await _profileService.GetAllAsync();
            return Ok(profiles);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProfileDto dto)
        {
            var updatedProfile = await _profileService.UpdateAsync(id, dto);
            if (updatedProfile == null) return NotFound();
            return Ok(updatedProfile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _profileService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
