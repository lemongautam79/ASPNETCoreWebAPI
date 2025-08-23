using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreWebAPI.Models
{

    public enum Gender
    {
        Male, 
        Female,
        Others
    }
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        public required string Email { get; set; }

        [Phone(ErrorMessage ="Invalid phone number")]
        [StringLength(10,ErrorMessage ="Phone number cannot be longer than 15 digits")]
        public string Phone { get; set; }

        public bool IsActive { get; set; } = false;

        public DateOnly Dob { get; set; }

        [Required(ErrorMessage ="Gender is required")]
        public Gender Gender { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
