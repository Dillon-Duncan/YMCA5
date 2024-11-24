using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YmcaApi
{
    [Table("Events")]
    public record Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; init; }

        [Required]
        [MaxLength(255)]
        [Column("Title")]
        public string? Title { get; init; }

        [Required]
        [MaxLength(1000)]
        [Column("Description")]
        public string? Description { get; init; }

        [Required]
        [Column("Date")]
        public DateTime Date { get; init; }
    }
}