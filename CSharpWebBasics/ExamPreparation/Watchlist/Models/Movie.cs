using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Director { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
