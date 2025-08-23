using ASPNETCoreWebAPI.Db;
using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebAPI.Services
{
    public class StudentService(ASPNETCoreWebAPIDbContext context, IConfiguration configuration) : IStudentService
    {
        // Create student
        public async Task<Student> CreateStudent(StudentDto request)
        {

            // Check if email already exists
            var existingEmail = await context.Students
                .AnyAsync(s => s.Email == request.Email);
            if (existingEmail)
                throw new InvalidOperationException("Email is already registered.");

            // Check if phone number already exists
            var existingPhone = await context.Students
                .AnyAsync(s => s.Phone == request.Phone);
            if (existingPhone)
                throw new InvalidOperationException("Phone number is already registered.");

            var student = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Gender = request.Gender,
                Dob = request.Dob,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Students.Add(student);
            await context.SaveChangesAsync();
            return student;
        }

        // Delete Student
        public async Task<bool> DeleteStudent(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
                return false;

            context.Students.Remove(student);
            await context.SaveChangesAsync();
            return true;
        }

        // Get All Students with pagination
        public async Task<IEnumerable<Student>> GetAllStudents(int page = 0, int limit = 0)
        {

            var query = context.Students.OrderBy(s => s.UpdatedAt).AsQueryable();

            if (page > 0 && limit > 0)
            {
                query = query
                    .Skip((page - 1) * limit)
                    .Take(limit);
            }

            return await query.ToListAsync();
        }

        // Get Student by Id
        public async Task<Student?> GetStudentById(int id)
        {
            return await context.Students.FindAsync(id);
        }

        // Update Student
        public async Task<Student?> UpdateStudent(int id, StudentDto request)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
                return null;

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.Phone = request.Phone;
            student.Gender = request.Gender;
            student.Dob = request.Dob;
            student.IsActive = request.IsActive;
            student.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();
            return student;
        }
    }
}
