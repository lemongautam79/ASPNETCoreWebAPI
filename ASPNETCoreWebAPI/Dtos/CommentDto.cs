using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreWebAPI.Dtos
{
    public class CommentDto
    {
        [Required(ErrorMessage ="Comment description is required")]
        public string Description { get; set; } = string.Empty;


        [Required(ErrorMessage ="PostId is required")]
        public int PostId { get; set; }


    }
}
