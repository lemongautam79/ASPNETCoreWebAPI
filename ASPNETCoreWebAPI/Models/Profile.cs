namespace ASPNETCoreWebAPI.Models
{
    public class Profile
    {

        public int Id { get; set; }

        public DateOnly? Dob { get; set; }

        public Gender Gender { get; set; }

        public string? Avatar_URL { get; set; }

        // 1 to 1 with User
        public int UserId { get; set; }
    }
}
