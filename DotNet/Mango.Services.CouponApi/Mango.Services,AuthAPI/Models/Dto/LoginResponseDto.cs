using Mango.Services.AuthAPI.Models.Dto;

namespace Mango.Services_AuthAPI.Models.Dto
{
    public class LoginResponseDto
    {
        public UserDto User {  get; set; }
        public string Token { get; set; }
    }
}
