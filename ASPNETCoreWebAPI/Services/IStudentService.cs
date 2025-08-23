using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Models;

namespace ASPNETCoreWebAPI.Services
{
    public interface IStudentService
    {
        // Get all students with pagination
        Task<IEnumerable<Student>> GetAllStudents(int page, int limit);

        // Get a student by Id
        Task<Student?> GetStudentById(int id);

        // Create a new student
        Task<Student> CreateStudent(StudentDto request);

        // Update an existing student
        Task<Student?> UpdateStudent(int id, StudentDto request);

        // Delete a student
        Task<bool> DeleteStudent(int id);
    }
}
