using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreWebAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Comment is required")]

        public required string Description { get; set; }

        public DateTime CreatedAt
        { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt
        { get; set; } = DateTime.UtcNow;

        
    }
}
