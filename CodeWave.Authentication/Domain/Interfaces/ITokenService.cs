using CodeWave.Authentication.Domain.Entities;

namespace CodeWave.Authentication.Domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(IdentityUser user);
    }
}
