using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;

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
        //movie/list/1
        public IActionResult List(int? id)
        {



            //Genre ile birlikte 2 adet liste bilgisini göndermem gerekecek
            //Bunu paket şeklinde gönderebiliriz
            //Sadece görüntü olşuturmak için oluşturulan, paketlenen bu sınıflara
            //viewmodel denir. İleride Entity olarak kullanacağız, model içine viewmodelleri paslicaz
            //sanırım şunu dedi, entity yani db ile oilgili olan her şeyi entity klasörüne atıcaz ileride
            //viewmodelleri ise model kısmını atacağız


            /////////////////////////////////////
            //var genrelist = new List<Genre>()
            //{
            //    new Genre {Name = "Dram" },
            //    new Genre {Name = "Action" },
            //    new Genre {Name = "Romantic" },
            //    new Genre {Name = "Comedy" }
            //};


            //var contoller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var genreid = RouteData.Values["id"];

            var movies = MovieRepository.Movies;

            if (id != null)
            {
                movies = movies.Where(movies => movies.GenreId == id).ToList();
            }

            var model = new MoviesViewModel()
            {
                Movies = movies
            };

            

            //üsttekileri artık componentle yapıyoz
            return View("MovieList", model);
        }

        // movie/details/1
        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }


    }
}
