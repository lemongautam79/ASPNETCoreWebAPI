using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreWebAPI.Models
{
    public enum Role
    {
        Admin,
        User,
        Student,
        Employee
    }
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(10, ErrorMessage = "Phone number cannot be longer than 15 digits")]
        public string Phone { get; set; } = string.Empty;

        public Role Role { get; set; } = Role.User;

        public bool IsActive { get; set; } = false;

        public DateTime CreatedAt
        { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt
        { get; set; } = DateTime.UtcNow;


        // 1 to 1 with User Profile
        public Profile? Profile { get; set; }

        // 1 to M (1 User: Multiple Posts)
        public int? PostId { get; set; }
        public Post? Post { get; set; }

        // M to N (Many User has many groups)

        public List<Group>? Groups { get; set; }
    }

}
