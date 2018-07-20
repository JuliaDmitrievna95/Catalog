using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FCatalog.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {

       

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }

        //public virtual ICollection<Favourite> Favourites { get; set; }

        //public ApplicationUser()
        //{
        //    Favourites = new List<Favourite>();
        //}

    }
    //public class Favourite
    //{

    //    public int Id { get; set; }
    //    public int? FilmId { get; set; }
    //    public virtual Film Film { get; set; }


    //    public string UserId { get; set; }

    //    public virtual ApplicationUser User { get; set; }

    //}

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        //public DbSet<Favourite> Favourites { get; set; }
          
            public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}