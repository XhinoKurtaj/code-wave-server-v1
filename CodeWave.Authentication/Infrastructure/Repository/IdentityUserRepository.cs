using CodeWave.Authentication.Domain.Entities;
using CodeWave.Authentication.Domain.Interfaces;
using CodeWave.Authentication.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeWave.Authentication.Infrastructure.Repository
{
    public class IdentityUserRepository : IIdentityUserRepository
    {
        private readonly ApplicationDbContext _context;

        public IdentityUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IdentityUser> FindOneAsync(Expression<Func<IdentityUser, bool>> filterExpression)
            => Task.Run(() => _context.IdentityUsers.FirstOrDefaultAsync(filterExpression));

        public async Task AddAsync(IdentityUser user)
            => await _context.IdentityUsers.AddAsync(user);
    }
}
