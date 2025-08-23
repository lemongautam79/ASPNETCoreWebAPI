using ASPNETCoreWebAPI.Models;

namespace ASPNETCoreWebAPI.Dtos
{
    public class StudentDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public bool IsActive { get; set; } = false;

        public DateOnly Dob { get; set; } = new DateOnly();

        public Gender Gender { get; set; } = Gender.Male;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
