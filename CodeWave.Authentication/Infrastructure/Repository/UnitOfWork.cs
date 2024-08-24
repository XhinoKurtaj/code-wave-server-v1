using CodeWave.Authentication.Domain.Interfaces;
using CodeWave.Authentication.Infrastructure.DataContext;

namespace CodeWave.Authentication.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private IIdentityUserRepository _identityUserRepository;
        private IRefreshTokenRepository _refreshTokenRepository;
        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
        }

        public IIdentityUserRepository IdentityUserRepository => _identityUserRepository ??= new IdentityUserRepository(_context);

        public IRefreshTokenRepository RefreshTokenRepository => throw new NotImplementedException();

        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
