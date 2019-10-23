namespace Hallo_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buch",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Autor = c.String(),
                        Seiten = c.Int(nullable: false),
                        Preis = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Buchgeschäft",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adresse = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BuchgeschäftBuch",
                c => new
                    {
                        Buchgeschäft_ID = c.Int(nullable: false),
                        Buch_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Buchgeschäft_ID, t.Buch_ID })
                .ForeignKey("dbo.Buchgeschäft", t => t.Buchgeschäft_ID, cascadeDelete: true)
                .ForeignKey("dbo.Buch", t => t.Buch_ID, cascadeDelete: true)
                .Index(t => t.Buchgeschäft_ID)
                .Index(t => t.Buch_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuchgeschäftBuch", "Buch_ID", "dbo.Buch");
            DropForeignKey("dbo.BuchgeschäftBuch", "Buchgeschäft_ID", "dbo.Buchgeschäft");
            DropIndex("dbo.BuchgeschäftBuch", new[] { "Buch_ID" });
            DropIndex("dbo.BuchgeschäftBuch", new[] { "Buchgeschäft_ID" });
            DropTable("dbo.BuchgeschäftBuch");
            DropTable("dbo.Buchgeschäft");
            DropTable("dbo.Buch");
        }
    }
}
