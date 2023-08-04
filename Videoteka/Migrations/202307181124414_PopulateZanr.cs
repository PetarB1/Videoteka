namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateZanr : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Zanrs (Id, Ime) VALUES (1, 'Action')");
            Sql("INSERT INTO Zanrs (Id, Ime) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Zanrs (Id, Ime) VALUES (3, 'Family')");
            Sql("INSERT INTO Zanrs (Id, Ime) VALUES (4, 'Romance')");
            Sql("INSERT INTO Zanrs (Id, Ime) VALUES (5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
