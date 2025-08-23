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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsActive { get; set; } = false;

        public DateOnly Dob { get; set; }

        public Gender Gender { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
