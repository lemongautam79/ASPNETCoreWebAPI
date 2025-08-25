using ASPNETCoreWebAPI.Models;

namespace ASPNETCoreWebAPI.Dtos
{
    public class ProfileResponseDto
    {
        public int Id { get; set; }
        public DateOnly? Dob { get; set; }
        public Gender Gender { get; set; }
        public string? Avatar_URL { get; set; }
        public Guid UserId { get; set; }
    }
}
