using ASPNETCoreWebAPI.Dtos;

namespace ASPNETCoreWebAPI.Services
{
    public interface ICommentService
    {
        Task<(IEnumerable<CommentResponseDto> Comments, int TotalCount)> GetAllAsync(CommentQueryDto query);

        Task<CommentResponseDto?> GetByIdAsync(int id);

        Task<IEnumerable<CommentResponseDto>> GetCommentsByPostIdAsync(int PostId);

        Task<CommentResponseDto> CreateAsync(CommentDto request);

        Task<CommentResponseDto> UpdateAsync(int id,CommentDto request);

        Task<bool> DeleteAsync(int id);

    }
}
