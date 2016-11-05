namespace Biblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregarEditorial : DbMigration
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
            
            AddColumn("dbo.Libroes", "Editorial_Id", c => c.Int());
            CreateIndex("dbo.Libroes", "Editorial_Id");
            AddForeignKey("dbo.Libroes", "Editorial_Id", "dbo.Editorials", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libroes", "Editorial_Id", "dbo.Editorials");
            DropIndex("dbo.Libroes", new[] { "Editorial_Id" });
            DropColumn("dbo.Libroes", "Editorial_Id");
            DropTable("dbo.Editorials");
        }
    }
}
