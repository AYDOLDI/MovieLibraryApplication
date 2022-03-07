using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Data
{
    public class GenreRepository
    {
        public static readonly List<Genre> _genres = null;

        static GenreRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre {Id = 1, Name = "Dram" },
                new Genre {Id = 2, Name= "Action" },
                new Genre {Id = 3, Name= "Romantic" },
                new Genre {Id = 4, Name = "Comedy" }
            };
        }

        public static List<Genre> Genres {
            get
            {
                return _genres;
            } 
        }

        public static void Add(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre GetById(int id)
        {
            return _genres.FirstOrDefault(g => g.Id == id);
            //eşleşen ilk kaydı alır yoksa null rdeğeri gönderir
        }
    }
}
