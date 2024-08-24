using CodeWave.Authentication.Domain.Dto;
using CodeWave.Authentication.Domain.Entities;

namespace CodeWave.Authentication.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto> RegisterAsync(IdentityUser user, string password);
        Task<ResponseDto> LoginAsync(string email, string password);
    }
}
