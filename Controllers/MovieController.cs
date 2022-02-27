using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using System.Collections.Generic;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public ActionResult Index()
        {
            return View();
        }

        //movie/list
        public IActionResult List()
        {
            var filmList = new List<Movie>()
            {
                new Movie {
                    Title = "QUEENS GAMBIT",
                    Details = "Detail 1",
                    Director = "Director of the Movie",
                    Cast = new string[] { "actor 1", "actor 2", "actor 3" },
                    ImageURL = "movie1.jpg"
                },
                new Movie {
                    Title = "12 ANGRY MEN",
                    Details = "Detail 2",
                    Director = "Director of the Movie",
                    Cast = new string[] { "actor 4", "actor 5" },
                    ImageURL = "movie2.jpg"
                },
                new Movie {
                    Title = "THE GODFATHER", 
                    Details = "Detail 3", 
                    Director = "Director of the Movie", 
                    Cast = new string[] { "actor 6", "actor 7", "actor 8", "actor 9"},
                    ImageURL = "movie3.jpg"
                }
            };


            //Genre ile birlikte 2 adet liste bilgisini göndermem gerekecek
            //Bunu paket şeklinde gönderebiliriz
            //Sadece görüntü olşuturmak için oluşturulan, paketlenen bu sınıflara
            //viewmodel denir. İleride Entity olarak kullanacağız, model içine viewmodelleri paslicaz
            //sanırım şunu dedi, entity yani db ile oilgili olan her şeyi entity klasörüne atıcaz ileride
            //viewmodelleri ise model kısmını atacağız
            var genrelist = new List<Genre>()
            {
                new Genre {Name = "Dram" },
                new Genre {Name = "Action" },
                new Genre {Name = "Romantic" },
                new Genre {Name = "Comedy" }
            };

            var model = new MovieGenreViewModel()
            {
                Movies = filmList,
                Genres = genrelist
            };

            return View("MovieList", model);
        }

        // movie/details
        public string Details(int id)
        {
            return "Film Detayları";
        }


    }
}
