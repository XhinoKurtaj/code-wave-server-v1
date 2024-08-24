using System.Linq.Expressions;
using CodeWave.Authentication.Domain.Entities;

namespace CodeWave.Authentication.Domain.Interfaces
{
    public interface IIdentityUserRepository
    {
        Task<IdentityUser> FindOneAsync(Expression<Func<IdentityUser, bool>> filterExpression);
        Task AddAsync(IdentityUser user);
    }
}
