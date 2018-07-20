using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using System.Net;
using FCatalog.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
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


        public ActionResult Details(int id = 0)
        {
            ViewBag.Id = id;
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }

            return View(film);
        }



        [HttpGet]
        public ActionResult EditReview(int id)
        {
            ViewBag.FilmId = id;

            return View();
        }

        [HttpPost]
        public ActionResult EditReview(Review review)
        {

            //Добавляем игрока в таблицу
            db.Reviews.Add(review);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return View();
        }

        public ActionResult ViewReview(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Film film = db.Films.Include(f => f.Reviews).FirstOrDefault(f => f.Id == id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }





        public ActionResult Contact()
        {
            ViewBag.Message = "Поиск по режиссеру";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Поиск по актеру";

            return View();
        }

        //[Authorize]
        //public ActionResult Cabinet()
        //{
        //    //var userId = User.Identity.GetUserId();
        //    ViewBag.Message = "Личный кабинет";

        //    return View();
        //}

        //[HttpPost]
        //[Authorize]
        //public ActionResult Favourite(int id)
        //{
        //    ViewBag.Message = "Избранное";

            

        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {

        //        db.Favourites.Add(new Favourite { UserId = User.Identity.GetUserId(), FilmId = id });
               
        //        db.SaveChanges();
        //    }
        //    return View("Index");
        //}






        //[HttpPost]
        //[Authorize]
        //public ActionResult Favourite(Favourite favourite)
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        db.Favourites.Add(favourite);
        //        db.SaveChanges();
        //    }


        //    return View();
        //}


        //[Authorize]
        //public ActionResult ViewLike()
        //{ 

        //    var favfilm = db.Films.Include(p => p.FavouriteId);
        //    return View(favfilm);



        //}

        //[Authorize]
        //public ActionResult ViewLike()
        //{
        //   Like like = db.
        //}

        [HttpPost]
        public ActionResult ActorSearch(string name)
        {
            var actors = db.Films.Where(a => a.Roles.Contains(name)).ToList();
            if (actors.Count <= 0)
            {
                ViewBag.Message = "Ничего не найдено :(";
            }
            return View(actors);
        }

        [HttpPost]
        public ActionResult ProducerSearch(string name)
        {
            var producers = db.Films.Where(a => a.Producer.Contains(name)).ToList();
            if (producers.Count <= 0)
            {
                ViewBag.Message = "Ничего не найдено :(";
            }
            return View(producers);
        }






    }
}