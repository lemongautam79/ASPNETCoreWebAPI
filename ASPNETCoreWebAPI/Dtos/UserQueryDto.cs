using ASPNETCoreWebAPI.Models;

namespace ASPNETCoreWebAPI.Dtos
{
    public class UserQueryDto
    {
        public string? Search { get; set; }    // search by name/email
        public int Page { get; set; } = 1;     // default page = 1
        public int Limit { get; set; } = 10;   // default size = 10

        public Role? Role { get; set; }        // filter by Role
        public bool? IsActive { get; set; }    // filter by Active status
    }
}
