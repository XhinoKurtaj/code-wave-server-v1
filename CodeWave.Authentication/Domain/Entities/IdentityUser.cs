using System.ComponentModel.DataAnnotations;

namespace CodeWave.Authentication.Domain.Entities
{
    public class IdentityUser
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Email { get; set; }

        public byte[] Password { get; set; }

        public byte[] PasswordSalt { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool IsEmailConfirmed { get; set; } = true;

        [Required]
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
    }
}
