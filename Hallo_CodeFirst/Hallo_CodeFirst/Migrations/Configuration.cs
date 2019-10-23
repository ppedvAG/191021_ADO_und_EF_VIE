namespace Hallo_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hallo_CodeFirst.EFContext>
    {
        public Configuration()
        {
            // AutomaticMigrationDataLossAllowed = true; // <- F�hrt zu datenverlust bei DropColumn/Table etc...
            AutomaticMigrationsEnabled = true; // Holzhammer -> Bei jeder Model�nderung wird ein neuer Migrationspunkt erstellt
            ContextKey = "Hallo_CodeFirst.EFContext";
        }

        protected override void Seed(Hallo_CodeFirst.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
