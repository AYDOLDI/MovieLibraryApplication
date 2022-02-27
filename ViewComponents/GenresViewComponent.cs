
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using System.Collections.Generic;

namespace MovieApp.ViewComponents
{
    public class GenresViewComponent: ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            var genrelist = new List<Genre>()
            {
                new Genre {Name = "Dram" },
                new Genre {Name = "Action" },
                new Genre {Name = "Romantic" },
                new Genre {Name = "Comedy" }
            };

            return View(genrelist);
        }

    }
}
