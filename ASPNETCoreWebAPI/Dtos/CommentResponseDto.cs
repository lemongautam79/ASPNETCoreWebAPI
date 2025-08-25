namespace ASPNETCoreWebAPI.Dtos
{
    public class CommentResponseDto
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int PostId { get; set; }
    }
}
