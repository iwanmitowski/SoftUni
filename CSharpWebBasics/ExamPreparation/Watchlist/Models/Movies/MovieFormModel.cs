using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models.Movies
{
    public class MovieFormModel
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
        public string Url { get; set; }

        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual IEnumerable<Genre> Genres { get; set; } = Enumerable.Empty<Genre>();
    }
}
