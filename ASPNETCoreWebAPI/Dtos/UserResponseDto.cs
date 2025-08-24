using ASPNETCoreWebAPI.Models;

namespace ASPNETCoreWebAPI.Dtos
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Role Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
