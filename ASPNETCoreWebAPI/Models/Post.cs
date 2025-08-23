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

        // 1 To M Comment (1 Post: Multiple Comments)
        public int? CommentId { get; set; }
        public Comment? Comment { get; set; }
    }
}
