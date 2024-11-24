using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YmcaApi
{
    [Table("News")]
    public record News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        [Column("Image")]
        public string? Image { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Headline")]
        public string? Headline { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column("Description")]
        public string? Description { get; set; }

        [Required]
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}