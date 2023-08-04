namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTipKupca : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TipKupcas (Id,Naziv) VALUES (1,'Ucenik')");
            Sql("INSERT INTO TipKupcas (Id,Naziv) VALUES (2,'Student')");
            Sql("INSERT INTO TipKupcas (Id,Naziv) VALUES (3,'Nezaposlen')");
            Sql("INSERT INTO TipKupcas (Id,Naziv) VALUES (4,'Zaposlen')");
            Sql("INSERT INTO TipKupcas (Id,Naziv) VALUES (5,'Penzioner')");
        }
        
        public override void Down()
        {
        }
    }
}
