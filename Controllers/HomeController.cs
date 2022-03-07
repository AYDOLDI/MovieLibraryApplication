using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Data;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var model = new HomePageViewModel
            {
                PopularMovies = MovieRepository.Movies
            };

            return View(model);

            //string Title = "Film Title";
            //string Details = "Film Details";
            //string Director = "Film Director";
            //string[] Cast = {"Actor 1", "Actor 2", "Actor 3"};
            //Üstteki veriler normalde DB üzerinden gelecek

            /*            
                        ViewBag.FilmTitle = Title;
                        ViewBag.FilmDetail = Details;
                        ViewBag.FilmDirector = Director;
                        ViewBag.Cast = Cast;
                        //Viewbag aracılığı ile buradaki verileri view'a taşıyabiliyoruz
                        //diğer yolu da "model", yani asıl kullancağımız yolu
            */
            /*
             return View();
            */


            //var movie = new Movie();

            //movie.Title = Title;
            //movie.Details = Details;
            //movie.Director = Director;
            //movie.Cast = Cast;
            //movie.ImageURL = "movie2.jpg";

            //return View(movie);




        }

        public IActionResult About()
        {
        //    var genrelist = new List<Genre>()
        //    {
        //        new Genre {Name = "Dram" },
        //        new Genre {Name = "Action" },
        //        new Genre {Name = "Romantic" },
        //        new Genre {Name = "Comedy" }
        //    };

            //return View(genrelist);


            //üsttekileri artık componentle yapıyoz
            return View();
        }

    }
}
