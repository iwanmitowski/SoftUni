using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Models;
using Watchlist.Models.Movies;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly WatchlistDbContext dbContext;
        private readonly UserManager<User> userManager;

        public MoviesController(
            WatchlistDbContext dbContext,
            UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            var movies = await dbContext.Movies
                .Select(m => new MovieDto()
                {
                    Description = m.Description,
                    Director = m.Director,
                    Genre = m.Genre.Name,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Title = m.Title,
                    Id = m.Id
                })
                .ToArrayAsync();

            var model = new AllMoviesQueryModel()
            {
                Movies = movies,
            };

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = new MovieFormModel()
            {
                Genres = await dbContext.Genres.ToArrayAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(HttpContext.User);

            var movie = new Movie()
            {
                Title = model.Title,
                Description = model.Description,
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.Url,
                Rating = model.Rating,
            };

            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();

            return View("All", "Movies");
        }

        public async Task<IActionResult> Mine()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            var movies = await dbContext.Movies
                .Where(m => m.UserId == user.Id)
                .Select(m => new MovieDto()
                {
                    Description = m.Description,
                    Director = m.Director,
                    Genre = m.Genre.Name,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Title = m.Title,
                    Id = m.Id
                })
                .ToArrayAsync();

            var model = new AllMoviesQueryModel()
            {
                Movies = movies,
            };

            return View(model);
        }
    }
}
