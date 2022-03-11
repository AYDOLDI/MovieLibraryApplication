using MovieApp.Entity;
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
                    Details = "Orphaned at the tender age of nine, prodigious introvert Beth Harmon discovers and masters the game of chess in 1960s USA. But child stardom comes at a price.",
                    Director = "Allan Scott",
                    //Cast = new string[] { "Anya Taylor-Joy", "Marcin Dorocinski", "Thomas Brodie" },
                    ImageURL = "11.jpg",
                    GenreId = 1
                },
                new Movie {
                    Id = 2,
                    Title = "THE GODFATHER",
                    Details = "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.",
                    Director = "Francis Ford Coppola",
                    //Cast = new string[] { "Marlon Brando", "Al Pacino" },
                    ImageURL = "22.jpg",
                    GenreId = 2
                },
                new Movie {
                    Id = 3,
                    Title = "12 ANGRY MEN",
                    Details = "The jury in a New York City murder trial is frustrated by a single member whose skeptical caution forces them to more carefully consider the evidence before jumping to a hasty verdict.",
                    Director = "Sidney Lumet",
                    //Cast = new string[] { "Henry Fonda", "Lee J. Cobb", "Martin Balsam", "John Fiedler"},
                    ImageURL = "33.jpg",
                    GenreId = 1
                },
                  new Movie {
                    Id = 4,
                    Title = "Django Unchained",
                    Details = "With the help of a German bounty-hunter, a freed slave sets out to rescue his wife from a brutal plantation-owner in Mississippi.",
                    Director = "Quentin Tarantino",
                    //Cast = new string[] { "Jamie Foxx", "Christoph Waltz", "Leonardo DiCaprio" },
                    ImageURL = "33.jpg",
                    GenreId = 2
                },
                new Movie {
                    Id = 5,
                    Title = "Once Upon Time In Hollywood",
                    Details = "A faded television actor and his stunt double strive to achieve fame and success in the final years of Hollywood's Golden Age in 1969 Los Angeles.",
                    Director = "Quentin Tarantino",
                    //Cast = new string[] { "Leonardo DiCaprio", "Brad Pitt" },
                    ImageURL = "22.jpg",
                    GenreId = 3
                },
                new Movie {
                    Id = 6,
                    Title = "Pulp Fiction",
                    Details = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Director = "Quentin Tarantino",
                    //Cast = new string[] { "John Travolta", "Uma Thurman", "Samuel L. Jackson", "Bruce Willis"},
                    ImageURL = "11.jpg",
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
            movie.Id = _movies.Count() + 1;
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public static void Edit(Movie m)
        {
            foreach (var item in _movies)
            {
                if(item.Id == m.Id)
                {
                    item.Title = m.Title;
                    item.Details = m.Details;
                    item.Director = m.Director;
                    item.ImageURL = m.ImageURL;
                    item.GenreId = m.GenreId;
                    break;
                }
            }
        }


        public static void Delete(int id)
        {

            var movie = GetById(id);

            if (movie!=null)
            {
                _movies.Remove(movie);
            }
        }


    }
}
