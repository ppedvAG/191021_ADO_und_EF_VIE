namespace Hallo_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Namensänderug : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "bu.Bücher", newName: "Bücherliste");
            RenameColumn(table: "bu.Bücherliste", name: "kaChing", newName: "Verkaufspreis");
            AlterColumn("bu.Bücherliste", "Verkaufspreis", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("bu.Bücherliste", "Verkaufspreis", c => c.Decimal(nullable: false, storeType: "money"));
            RenameColumn(table: "bu.Bücherliste", name: "Verkaufspreis", newName: "kaChing");
            RenameTable(name: "bu.Bücherliste", newName: "Bücher");
        }
    }
}
