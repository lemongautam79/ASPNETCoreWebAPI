using ASPNETCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASPNETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        // Static in-memory employee list
        private static List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Email = "john@example.com", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Employee { Id = 2, Name = "Jane Smith", Email = "jane@example.com", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        //GET: api/employee
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Employees);
        }

        // GET: api/employee/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound(new { Message = "Employee not found" });

            return Ok(employee);
        }

        //POST: api/employee
        [HttpPost]
        public IActionResult Create([FromBody] Employee newEmployee)
        {
            if (Employees.Any(e => e.Id == newEmployee.Id))
                return BadRequest(new { Message = "Employee with this ID already exists" });

            newEmployee.CreatedAt = DateTime.UtcNow;
            newEmployee.UpdatedAt = DateTime.UtcNow;

            Employees.Add(newEmployee);
            return CreatedAtAction(nameof(GetById), new { id = newEmployee.Id }, newEmployee);
        }

        //PUT: api/employee/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound(new { Message = "Employee not found" });

            employee.Name = updatedEmployee.Name;
            employee.Email = updatedEmployee.Email;
            employee.UpdatedAt = DateTime.UtcNow;

            return Ok(employee);
        }

        //DELETE: api/employee/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound(new { Message = "Employee not found" });

            Employees.Remove(employee);
            return NoContent();
        }
    }
}
