using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
