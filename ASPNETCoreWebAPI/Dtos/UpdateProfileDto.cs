using ASPNETCoreWebAPI.Models;

namespace ASPNETCoreWebAPI.Dtos
{
    public class UpdateProfileDto
    {
        public DateOnly? Dob { get; set; }
        public Gender Gender { get; set; }
        public string? Avatar_URL { get; set; }
    }
}
