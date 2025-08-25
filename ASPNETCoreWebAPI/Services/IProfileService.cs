using ASPNETCoreWebAPI.Dtos;

namespace ASPNETCoreWebAPI.Services
{
    public interface IProfileService
    {
        Task<ProfileResponseDto> CreateAsync(CreateProfileDto dto);
        Task<ProfileResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<ProfileResponseDto>> GetAllAsync();
        Task<ProfileResponseDto?> UpdateAsync(int id, UpdateProfileDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
