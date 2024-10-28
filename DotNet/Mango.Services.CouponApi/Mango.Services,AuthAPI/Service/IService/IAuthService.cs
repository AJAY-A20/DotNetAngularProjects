using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services_AuthAPI.Models.Dto;
namespace Mango.Services_AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string RoleName);
    }
}
