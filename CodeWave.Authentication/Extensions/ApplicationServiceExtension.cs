using CodeWave.Authentication.Application.Services;
using CodeWave.Authentication.Domain.Interfaces;
using CodeWave.Authentication.Infrastructure.DataContext;
using CodeWave.Authentication.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace CodeWave.Authentication.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddAppService(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityUserRepository, IdentityUserRepository>();
            services.AddScoped<IAuthService, CodeWave.Authentication.Application.Services.AuthService>();
            services.AddSingleton<ITokenService, TokenService>();

            return services;
        }
    }
}
