namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Ime", c => c.String(nullable: false));
            AlterColumn("dbo.Kupacs", "Ime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kupacs", "Ime", c => c.String());
            AlterColumn("dbo.Films", "Ime", c => c.String());
        }
    }
}
