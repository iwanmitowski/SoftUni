using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Movies");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}