namespace VIdly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RentedDate = c.DateTime(nullable: false),
                        ReturnedDate = c.DateTime(),
                        Customer_id = c.Int(),
                        Movie_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .ForeignKey("dbo.Movies", t => t.Movie_id)
                .Index(t => t.Customer_id)
                .Index(t => t.Movie_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_id" });
            DropIndex("dbo.Rentals", new[] { "Customer_id" });
            DropTable("dbo.Rentals");
        }
    }
}
