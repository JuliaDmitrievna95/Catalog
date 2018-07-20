using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCatalog.Models;

namespace FCatalog.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Roles { get; set; }
        public string Image { get; set; }


        public ICollection<Review> Reviews { get; set; }
        public Film()
        {
            Reviews = new List<Review>();
        }




    }



    public class ViewsFilm
    {
        public IEnumerable<Film> Films { get; set; }
        public SelectList Genre { get; set; }
    }


}