using Mango.Services_AuthAPI.Models;

namespace Mango.Services_AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
