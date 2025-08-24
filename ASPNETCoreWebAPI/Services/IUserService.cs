using ASPNETCoreWebAPI.Dtos;

namespace ASPNETCoreWebAPI.Services
{
    public interface IUserService
    {
        Task<(IEnumerable<UserResponseDto> Users, int TotalCount)> GetAllAsync(UserQueryDto query);

        Task<UserResponseDto> GetByIdAsync(Guid id);

        Task<bool> DeleteAsync(Guid id);

    }
}
