using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YmcaApi
{
    [Table("Chats")]
    public record Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; init; }

        [Required]
        [MaxLength(100)]
        [Column("User1")]
        public string? User1 { get; init; }

        [Required]
        [MaxLength(100)]
        [Column("User2")]
        public string? User2 { get; init; }
    }
}