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

        private IMovieRepository _repository;
        private MovieListDbContext _context;

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository, MovieListDbContext con)
        {
            _logger = logger;
            _repository = repository;
            _context = con;
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
                _context.Add(appResponse);
                _context.SaveChanges();
                return View("Confirmation", appResponse);
            }
        }
        public IActionResult NewMoviesDisplay()
        {
            return View(_repository.Movies);
        }

        //The actions below were added to allow users to remove movies and to edit Movie records
        [HttpPost]
        public IActionResult RemoveMovie(int MovieId)
        {
            Movies Movie = _context.Movies.Find(MovieId);
            _context.Movies.Remove(Movie);
            _context.SaveChanges();
            return RedirectToAction("NewMoviesDisplay");
        }
        [HttpPost]
        public IActionResult EditMovieForm(int MovieId)
        {
            Movies Movie = _context.Movies.Single(m => m.id == MovieId);
            return View(Movie);
        }
        [HttpPost]
        public IActionResult EditMovie(Movies Movie)
        {
            if(ModelState.IsValid)
            { 
                Movies OldMovie = _context.Movies.Single(m => m.id == Movie.id);
                _context.Movies.Remove(OldMovie);
                _context.Movies.Add(Movie);
                _context.SaveChanges();
                return RedirectToAction("NewMoviesDisplay");
            }
            else
            {
                return RedirectToAction("NewMoviesDisplay");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
