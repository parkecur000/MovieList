using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    public static class TempStorage
    {
        private static List<Movies> movies = new List<Movies>(); //creates the list

        public static IEnumerable<Movies> Movies => movies; //=>is the sign for a lambda function. This creates a function that will store the applications
                                         //Movies is the name of the method. movies is the list of type <Movies> (which is the class)
        public static void AddMovie(Movies movie) //Adds a movie to the movies list
        {
            movies.Add(movie);
        }
    }
}
