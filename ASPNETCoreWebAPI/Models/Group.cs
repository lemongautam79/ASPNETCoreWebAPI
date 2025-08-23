using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASPNETCoreWebAPI.Models
{
    public class Group
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Group Name is required")]
        public required string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // M to N (Many user has many groups)
        [JsonIgnore]
        public List<User>? Users { get; set; }

    }
}
