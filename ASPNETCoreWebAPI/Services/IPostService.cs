using ASPNETCoreWebAPI.Dtos;

namespace ASPNETCoreWebAPI.Services
{
    public interface IPostService
    {
        Task<(IEnumerable<PostResponseDto> Posts, int TotalCount)> GetAllAsync(PostQueryDto query);

        Task<PostResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<PostResponseDto>> GetPostsByUserIdAsync(Guid userId);
        Task<PostResponseDto> CreateAsync(PostDto request);
        Task<PostResponseDto?> UpdateAsync(int id, PostDto request);
        Task<bool> DeleteAsync(int id);
    }
}
