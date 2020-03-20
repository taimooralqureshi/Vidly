namespace VIdly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (Id,Name) values(1,'Action')");
            Sql("insert into Genres (Id,Name) values(2,'Romance')");
            Sql("insert into Genres (Id,Name) values(3,'Sci-Fiction')");
            Sql("insert into Genres (Id,Name) values(4,'Suspense')");
            Sql("insert into Genres (Id,Name) values(5,'Comedy')");

        }

        public override void Down()
        {
        }
    }
}
