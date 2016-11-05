namespace Biblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Libroes", "Año", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Libroes", "Año");
        }
    }
}
