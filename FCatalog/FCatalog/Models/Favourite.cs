using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCatalog.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public int? FilmId { get; set; }
        public virtual Film Film { get; set; }


        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}