using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YmcaApi
{
    [Table("Messages")]
    public record Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; init; }

        [Required]
        [MaxLength(100)]
        [Column("FromUser")]
        public string? FromUser { get; init; }

        [Required]
        [MaxLength(100)]
        [Column("ToUser")]
        public string? ToUser { get; init; }

        [Required]
        [MaxLength(1000)]
        [Column("Text")]
        public string? Text { get; init; }

        [Required]
        [Column("Date")]
        public DateTime Date { get; init; }
    }
}