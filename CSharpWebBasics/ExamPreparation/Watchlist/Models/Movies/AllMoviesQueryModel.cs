namespace Watchlist.Models.Movies
{
    public class AllMoviesQueryModel
    {
        public IEnumerable<MovieDto> Movies { get; set; } = new List<MovieDto>();
    }
}
