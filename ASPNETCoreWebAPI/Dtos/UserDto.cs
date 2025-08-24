using ASPNETCoreWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreWebAPI.Dtos
{
    public class UserDto
    {

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(10, ErrorMessage = "Phone number must be 10 digits")]
        public string Phone { get; set; } = string.Empty;

        // Optional: if you want client to specify role (default = User)
        public Role Role { get; set; } = Role.User;
    }
}
