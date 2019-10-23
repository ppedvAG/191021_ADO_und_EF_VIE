namespace Hallo_CodeFirst_DBFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFContext : DbContext
    {
        public EFContext()
            : base("name=DatabaseFirstModel")
        {
        }

        public virtual DbSet<Bücher> Bücher { get; set; }
        public virtual DbSet<Buchgeschäft> Buchgeschäft { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bücher>()
                .Property(e => e.kaChing)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bücher>()
                .HasMany(e => e.Buchgeschäft)
                .WithMany(e => e.Bücher)
                .Map(m => m.ToTable("BuchgeschäftBuch").MapLeftKey("Buch_ID"));
        }
    }
}
