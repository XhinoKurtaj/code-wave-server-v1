using CodeWave.Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeWave.Authentication.Infrastructure.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>()
                .HasMany(uc => uc.RefreshTokens)
                .WithOne(rt => rt.IdentityUser)
                .HasForeignKey(rt => rt.IdentityUserId);

            // Global filters to exclude soft-deleted records
            modelBuilder.Entity<IdentityUser>().HasQueryFilter(uc => !uc.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}
