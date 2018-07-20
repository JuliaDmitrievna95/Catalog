using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCatalog.Models;
using System.Data.Entity;

namespace FCatalog.Models
{
    public class FilmContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Review> Reviews { get; set; }


    }


    public class FilmDbInitializer : DropCreateDatabaseAlways<FilmContext>
    {
        protected override void Seed(FilmContext db)
        {


            db.Films.Add(new Film
            {
                Name = "Джанго освобожденный",
                Producer = "Квентин Тарантино",
                Year = 2012,
                Genre = "Драма",
                Roles = "Джейми Фокс, Кристоф Вальц, Леонардо ДиКаприо, Керри Вашингтон, Сэмюэл Л. Джексон",
                Image = "~/Pictures/2.jpg"
            });

            db.Films.Add(new Film
            {
                Name = "Волк с Уолл-стрит",
                Producer = "Мартин Скорсезе",
                Year = 2013,
                Genre = "Комедия",
                Roles = "Леонардо ДиКаприо, Джона Хилл, Марго Робби, Кайл Чандлер, Роб Райнер",
                Image = "~/Pictures/3.jpg"
            });

            db.Films.Add(new Film
            {
                Name = "Бесславные ублюдки",
                Producer = "Квентин Тарантино",
                Year = 2009,
                Genre = "Боевик",
                Roles = "Брэд Питт, Кристоф Вальц, Мелани Лоран, Даниэль Брюль, Дайан Крюгер",
                Image = "~/Pictures/4.jpg"
            });

            db.Films.Add(new Film
            {
                Name = "Темный рыцарь",
                Producer = "Кристофер Нолан",
                Year = 2008,
                Genre = "Фантастика",
                Roles = "Кристиан Бэйл, Хит Леджер, Аарон Экхарт, Мэгги Джилленхол, Гари Олдман",
                Image = "~/Pictures/5.jpg"
            });

            db.Films.Add(new Film
            {
                Name = "Малавита",
                Producer = "Люк Бессон",
                Year = 2013,
                Genre = "Боевик",
                Roles = "Кристиан Бэйл, Хит Леджер, Аарон Экхарт, Мэгги Джилленхол, Гари Олдман",
                Image = "~/Pictures/6.jpg"
            });

            db.Films.Add(new Film
            {
                Name = "Остров проклятых",
                Producer = "Мартин Скорсезе",
                Year = 2009,
                Genre = "Триллер",
                Roles = "Леонардо ДиКаприо, Марк Руффало, Бен Кингсли, Макс фон Сюдов, Мишель Уильямс",
                Image = "~/Pictures/7.jpg"
            });

            db.Films.Add(new Film
            {
                Name = "Омерзительная восьмерка",
                Producer = "Квентин Тарантино",
                Year = 2015,
                Genre = "Триллер",
                Roles = "Курт Рассел, Сэмюэл Л. Джексон, Тим Рот, Майкл Мэдсен, Дженнифер Джейсон Ли",
                Image = "/Pictures/8.jpg"
            });
            base.Seed(db);
        }
    }

}