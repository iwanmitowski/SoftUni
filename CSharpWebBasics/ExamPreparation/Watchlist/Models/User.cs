using Microsoft.AspNetCore.Identity;

namespace Watchlist.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Movie> WatchedMovies { get; set; } 
            = new HashSet<Movie>();
    }
}
