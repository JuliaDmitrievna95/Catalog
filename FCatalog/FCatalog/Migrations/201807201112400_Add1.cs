namespace FCatalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Favourites", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Favourites", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Favourites", new[] { "FilmId" });
            DropIndex("dbo.Favourites", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "FilmId" });
            DropTable("dbo.Favourites");
            DropTable("dbo.Films");
            DropTable("dbo.Reviews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Person = c.String(),
                        Text = c.String(),
                        Date = c.String(),
                        FilmId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Producer = c.String(),
                        Year = c.Int(nullable: false),
                        Genre = c.String(),
                        Roles = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Reviews", "FilmId");
            CreateIndex("dbo.Favourites", "UserId");
            CreateIndex("dbo.Favourites", "FilmId");
            AddForeignKey("dbo.Favourites", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Favourites", "FilmId", "dbo.Films", "Id");
            AddForeignKey("dbo.Reviews", "FilmId", "dbo.Films", "Id");
        }
    }
}
