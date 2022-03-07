
using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;
using System.Collections.Generic;

namespace MovieApp.ViewComponents
{
    public class GenresViewComponent: ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];
            return View(GenreRepository.Genres);
        }

    }
}
