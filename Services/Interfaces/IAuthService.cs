using NexCart.DTOs.Auth;

namespace NexCart.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequest);
        Task<bool> SignUpAsync(SignUpRequestDto signUpRequest);
        Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);
    }
}
