using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Models;

namespace ASPNETCoreWebAPI.Services
{
    public interface IAuthService
    {

        Task<User?> RegisterAsync(UserDto request);

        Task<TokenResponseDto?> LoginAsync(UserDto request);

        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
    }
}
