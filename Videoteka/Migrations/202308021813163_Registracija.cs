namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registracija : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Adresa", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Telefon", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Telefon");
            DropColumn("dbo.AspNetUsers", "Adresa");
        }
    }
}
