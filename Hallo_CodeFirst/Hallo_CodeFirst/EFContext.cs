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
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        // Koniguration:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Annotations [Table("Tabellenname")] wieder überschreiben !

            modelBuilder.Entity<Buch>().ToTable("Bücher");
            modelBuilder.Entity<Buch>().Property(x => x.Preis)
                                       .HasColumnName("kaChing")
                                       .HasColumnType("money");
        }

        public DbSet<Buch> Buch { get; set; }
        public DbSet<Buchgeschäft> Buchgeschäft { get; set; }
    }

}
