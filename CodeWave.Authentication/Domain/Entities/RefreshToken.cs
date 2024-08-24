using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeWave.Authentication.Domain.Entities
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("IdentityUser")]
        public Guid IdentityUserId { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Token { get; set; }

        [Required]
        public DateTime ExpiresAt { get; set; }

        [Required]

        public virtual required IdentityUser IdentityUser { get; set; }
    }
}
