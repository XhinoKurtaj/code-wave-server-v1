namespace CodeWave.Authentication.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IIdentityUserRepository IdentityUserRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        Task<int> CompleteAsync();
    }
}
