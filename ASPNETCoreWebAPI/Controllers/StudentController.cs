using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Models;
using ASPNETCoreWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET api/student?page=1&limit=10
        [HttpGet]
        public async Task<IActionResult> GetAllStudents([FromQuery] int page = 0, [FromQuery] int limit = 0)
        {
            var students = await _studentService.GetAllStudents(page, limit);
            return Ok(students);
        }

        // GET api/student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
                return NotFound(new { message = "Student not found" });

            return Ok(student);
        }

        // POST api/student
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto request)
        {
            try
            {
                var student = await _studentService.CreateStudent(request);
                return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        // PUT api/student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto request)
        {
            var student = await _studentService.UpdateStudent(id, request);
            if (student == null)
                return NotFound(new { message = "Student not found" });

            return Ok(student);
        }

        // DELETE api/student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.DeleteStudent(id);
            if (!deleted)
                return NotFound(new { message = "Student not found" });

            return NoContent();
        }
    }
}
