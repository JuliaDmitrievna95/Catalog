using FCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCatalog.Controllers
{
    public class HomeController : Controller
    {
        FilmContext db = new FilmContext();

        public ActionResult Index(string genre, int page = 1)
        {
            IEnumerable<Film> films = db.Films;
            IEnumerable<Review> reviews = db.Reviews;


            if (!String.IsNullOrEmpty(genre) && !genre.Equals("Все"))
            {
                films = films.Where(p => p.Genre == genre);
            }

            ViewsFilm vf = new ViewsFilm
            {
                Films = films.ToList(),
                Genre = new SelectList(new List<string>()
            {
                "Все",
                "Драма",
                "Комедия",
                "Боевик",
                "Фантастика",
                "Триллер"
            })
            };


            return View(vf);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}