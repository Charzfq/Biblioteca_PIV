namespace Biblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Editorials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Libroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Año = c.Int(nullable: false),
                        Editorial_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Editorials", t => t.Editorial_Id)
                .Index(t => t.Editorial_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libroes", "Editorial_Id", "dbo.Editorials");
            DropIndex("dbo.Libroes", new[] { "Editorial_Id" });
            DropTable("dbo.Libroes");
            DropTable("dbo.Editorials");
        }
    }
}
