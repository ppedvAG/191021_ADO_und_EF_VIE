using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Hallo_CodeFirst
{
    // Minimalkonfiguration 
    public class EFContext : DbContext
    {
        // Wenn man keinen eigenen Connectionstring angibt, nimmt er die lokale SQLEXPRESS-DB instanz und erstellt eine neue DB

        public EFContext() : base(@"Server=(localdb)\mssqllocaldb;Database=Buchverwaltung;Trusted_Connection=true")
        {
            // Für Testzwecke:
            // Database.SetInitializer(new DropCreateDatabaseAlways<EFContext>()); // <--- Bei jedem Programmstart
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFContext>());


            // Code-First-Migration:

            // enable-migration  // <---- bei Programmstart
            // add-migration // <--- schönen namen aussuchen
            // update-database  // -TargetMigration XYZ

            // Der erste, der das Programm startet, updated die DB ;) 
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFContext,Migrations.Configuration>());
        }

        // Koniguration:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Annotations [Table("Tabellenname")] wieder überschreiben !

            modelBuilder.Entity<Buch>().ToTable("Bücherliste", "bu");
            modelBuilder.Entity<Buch>().Property(x => x.Preis)
                                      .HasColumnName("Verkaufspreis")
                                      .HasColumnType("decimal");
        }

        public DbSet<Buch> Buch { get; set; }
        public DbSet<Buchgeschäft> Buchgeschäft { get; set; }
    }

}
