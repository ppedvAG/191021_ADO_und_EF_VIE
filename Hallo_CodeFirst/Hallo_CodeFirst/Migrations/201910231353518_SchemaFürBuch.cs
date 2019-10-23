namespace Hallo_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchemaFürBuch : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Buch", newName: "Bücher");
            MoveTable(name: "dbo.Bücher", newSchema: "bu");
            RenameColumn(table: "bu.Bücher", name: "Preis", newName: "kaChing");
            AlterColumn("bu.Bücher", "kaChing", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("bu.Bücher", "kaChing", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            RenameColumn(table: "bu.Bücher", name: "kaChing", newName: "Preis");
            MoveTable(name: "bu.Bücher", newSchema: "dbo");
            RenameTable(name: "dbo.Bücher", newName: "Buch");
        }
    }
}
