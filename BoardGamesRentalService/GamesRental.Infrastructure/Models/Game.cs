using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GamesRental.Infrastructure.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName="Varchar")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public int InStock { get; set; }
        [Required]
        public int Price { get; set; }


    }
}
