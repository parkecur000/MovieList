using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Controllers
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
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewMovies()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMovies(Movies appResponse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                TempStorage.AddMovie(appResponse); //Adds the movie to the movies list by calling the AddMovie method
                return View("Confirmation", appResponse);
            }
        }
        public IActionResult NewMoviesDisplay()
        {
            return View(TempStorage.Movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
