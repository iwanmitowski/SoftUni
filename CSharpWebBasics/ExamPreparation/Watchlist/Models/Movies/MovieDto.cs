namespace Watchlist.Models.Movies
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Rating { get; set; }

        public string Genre { get; set; }
    }
}
