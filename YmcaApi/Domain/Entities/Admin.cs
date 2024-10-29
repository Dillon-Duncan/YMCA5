using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YmcaApi
{
    [Table("Admins")]
    public record Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; init; }

        [Required]
        [MaxLength(50)]
        [Column("Username")]
        public string? Username { get; init; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        [Column("EmailAddress")]
        public string? EmailAddress { get; init; }

        [Required]
        [MaxLength(100)]
        [Column("Password")]
        public string? Password { get; init; }
    }
}