namespace ASPNETCoreWebAPI.Dtos
{
    public class PostQueryDto
    {
        public string? Search { get; set; }        // search by Title or Description
        public Guid? UserId { get; set; }          // filter by UserId
        public DateTime? FromDate { get; set; }    // filter by created date from
        public DateTime? ToDate { get; set; }      // filter by created date to
        public int Page { get; set; } = 1;         // default page
        public int Limit { get; set; } = 10;       // default limit
    }
}
