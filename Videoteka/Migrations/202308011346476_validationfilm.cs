namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationfilm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Ime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "Ime", c => c.String(nullable: false));
        }
    }
}
