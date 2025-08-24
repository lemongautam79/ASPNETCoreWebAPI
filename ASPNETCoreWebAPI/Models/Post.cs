using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreWebAPI.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Post Title is required")]
        public required string Title { get; set; }


        [Required(ErrorMessage = "Post Description is required")]

        public required string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // 1-to-Many for Comments
        public List<Comment>? Comments { get; set; }


        // **Many-to-1: Each Post has one User**
        [Required]
        public Guid UserId { get; set; }       // FK to User
        public User? User { get; set; }
    }
}
