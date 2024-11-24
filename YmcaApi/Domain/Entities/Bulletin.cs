using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YmcaApi
{
    [Table("Bulletins")]
    public record Bulletin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; init; }

        [Required]
        [MaxLength(1000)]
        [Column("Message")]
        public string? Message { get; init; }

        [Required]
        [Column("Date")]
        public DateTime Date { get; init; }
    }
}