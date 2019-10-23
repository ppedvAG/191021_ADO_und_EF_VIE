namespace Hallo_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Preisbindung : DbMigration
    {
        public override void Up()
        {
            AddColumn("bu.Bücher", "Preisbindung", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("bu.Bücher", "Preisbindung");
        }
    }
}
