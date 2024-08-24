namespace CodeWave.Authentication.Domain.Interfaces
{
    public interface IRefreshTokenRepository
    {
        void RefreshTokenAsync(string refreshToken);
    }
}
