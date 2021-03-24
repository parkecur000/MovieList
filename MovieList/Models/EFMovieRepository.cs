using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieListDbContext _context;

        public EFMovieRepository (MovieListDbContext context)
        {
            _context = context;
        }
        public IQueryable<Movies> Movies => _context.Movies;
    }
}
