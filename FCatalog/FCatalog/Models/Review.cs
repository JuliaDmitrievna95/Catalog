using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCatalog.Models;

namespace FCatalog.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }

        public int? FilmId { get; set; }
        public Film Film { get; set; }
    }

}