namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Film_Id = c.Int(nullable: false),
                        Kupac_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kupacs", t => t.Kupac_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Kupac_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Kupac_Id", "dbo.Kupacs");
            DropForeignKey("dbo.Rentals", "Film_Id", "dbo.Films");
            DropIndex("dbo.Rentals", new[] { "Kupac_Id" });
            DropIndex("dbo.Rentals", new[] { "Film_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
