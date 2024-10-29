using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YmcaApi
{
    [Table("Users")]
    public record User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; init; }

        [Required]
        [MaxLength(100)]
        [Column("FullName")]
        public string? FullName { get; init; }

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
        [Phone]
        [MaxLength(20)]
        [Column("PhoneNumber")]
        public string? PhoneNumber { get; init; }

        [Required]
        [MaxLength(100)]
        [Column("City")]
        public string? City { get; init; }

        [Required]
        [MaxLength(100)]
        [Column("Password")]
        public string? Password { get; init; }

        [Required]
        [Column("Member")]
        public MembershipType Member { get; init; }

        [Required]
        [Column("Volunteer")]
        public bool Volunteer { get; init; }
    }
}