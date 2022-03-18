using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Entity;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
       {

        //If it's private and readonly, the benefit is that
        //you can't inadvertently change it from another part of
        //that class after it is initialized. The readonly modifier
        //ensures the field can only be given a value during its
        //initialization or in its class constructor.
        //constructordan sonra değişmesi gerekmiyor, o yüzden readonly
        private readonly MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }


        // GET: MovieController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //movie/list
        //movie/list/1
        [HttpGet]
        public IActionResult List(int? id, string q)
        {
            //q buraya arama yapıldığında geliyor. arama yapılmadığında sadece listeye bakıldığında q'ya değer girilmesi gerekmez mi? soru işareti yok çünkü



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

            //var movies = MovieRepository.Movies;

            var movies = _context.Movies.AsQueryable();


            if (id != null)
            {
                movies = movies.Include(m => m.Genres).Where(m => m.Genres.Any(g =>g.Id==id));
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(n => n.Title.ToLower().Contains(q.ToLower()));
            }

            var model = new MoviesViewModel()
            {
                Movies = movies.ToList()
            };

            

            //üsttekileri artık componentle yapıyoz
            return View("MovieList", model);
        }

        // movie/details/1
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_context.Movies.Find(id));
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
        }

        [HttpPost]
        //public IActionResult Create(string title, string details, string director, string imageurl, int genreid)
        public IActionResult Create(Movie m)
        {
            //model binding araciliğla parametreler kendiliğinden set ediliyor
            //movieid veritabanında ve dizi olan cast ileride model binding içinde işlemek icin es gectik şimdilik

            /*var m = new Movie()
            {
                Title = title,
                Details = details,
                Director = director,
                ImageURL = imageurl,
                GenreId = genreid
            };*/
            if (ModelState.IsValid)
            {//movie içinden gelen alanlar kriterlerden geçmiş doğru şekilde
                //geliyor ise true döner

                //MovieRepository.add(m);
                _context.Movies.Add(m);
                _context.SaveChanges();
                
                TempData["Message"] = $"The movie that name is {m.Title} has been created";
                return RedirectToAction("List");
            }

            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
            
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");

            return View(_context.Movies.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {//movie içinden gelen alanlar kriterlerden geçmiş doğru şekilde
                //geliyor ise true döner

                //MovieRepository.Edit(m);

                _context.Movies.Update(m);
                _context.SaveChanges();
                return RedirectToAction("Details", "Movie", new { @id = m.Id });
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(m);
           
            //oradaki new bir enourmous tip. bu sayede edite id bilgisi gönderiyoruz
        }


        public IActionResult Delete(int id, string Title)
        {
            //MovieRepository.Delete(id);
            var entity = _context.Movies.Find(id);
            _context.Movies.Remove(entity);
            _context.SaveChanges();
            TempData["Message"] = $"The movie that name is {Title} has been deleted";
            return RedirectToAction("List");
        }


    }
}
