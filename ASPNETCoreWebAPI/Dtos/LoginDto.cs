using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreWebAPI.Dtos
{
    public class LoginDto
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;
    }
}
