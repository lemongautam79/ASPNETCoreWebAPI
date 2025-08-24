using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreWebAPI.Dtos
{
    public class PostDto
    {
        [Required(ErrorMessage = "Post Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Post Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "UserId is required")]
        public Guid UserId { get; set; }
    }
}
