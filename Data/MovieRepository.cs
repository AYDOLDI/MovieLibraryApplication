using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie {
                    Id = 1,
                    Title = "QUEENS GAMBIT",
                    Details = "Detail 1",
                    Director = "Director of the Movie",
                    Cast = new string[] { "actor 1", "actor 2", "actor 3" },
                    ImageURL = "movie1.jpg",
                    GenreId = 1
                },
                new Movie {
                    Id = 2,
                    Title = "THE GODFATHER",
                    Details = "Detail 2",
                    Director = "Director of the Movie",
                    Cast = new string[] { "actor 4", "actor 5" },
                    ImageURL = "movie2.jpg",
                    GenreId = 2
                },
                new Movie {
                    Id = 3,
                    Title = "12 ANGRY MEN",
                    Details = "Detail 3",
                    Director = "Director of the Movie",
                    Cast = new string[] { "actor 6", "actor 7", "actor 8", "actor 9"},
                    ImageURL = "movie3.jpg",
                    GenreId = 1
                },
                  new Movie {
                    Id = 4,
                    Title = "Django Unchained",
                    Details = "Detail 4",
                    Director = "Director of the Movie",
                    Cast = new string[] { "actor 9", "actor 20", "actor 11" },
                    ImageURL = "movie3.jpg",
                    GenreId = 2
                },
                new Movie {
                    Id = 5,
                    Title = "Once Upon Time In Hollywood",
                    Details = "Detail 5",
                    Director = "Director of the Movie",
                    Cast = new string[] { "actor 12", "actor 13" },
                    ImageURL = "movie2.jpg",
                    GenreId = 3
                },
                new Movie {
                    Id = 6,
                    Title = "Pulp Fiction",
                    Details = "Detail 6",
                    Director = "Director of the Movie",
                    Cast = new string[] { "actor 14", "actor 15", "actor 16", "actor 9"},
                    ImageURL = "movie1.jpg",
                    GenreId = 1
                }
            };
        }


        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }

        public static void add(Movie movie)
        {
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

    }
}
