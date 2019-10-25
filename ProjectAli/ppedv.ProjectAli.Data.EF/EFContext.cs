using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ppedv.ProjectAli.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.ProjectAli.Data.EF
{
    public class EFContext : DbContext
    {
        // NuGet:
        // Microsoft.EntityFrameworkCore
        // Microsoft.EntityFrameworkCore.SQLServer  <--- Provider !!!! 

        public DbSet<Airport> Airport { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<AircraftType> AircraftType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjectAli_Test;Trusted_Connection=true;");
#else
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjectAli_Produktiv;Trusted_Connection=true;");
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguration
            // Properties ignorieren:
            // '[NotMapped]' Attribut über dem Property oder 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.
            
            // Schritte für CodeFirst - Migration:
            // 1) NuGetPackage Microsoft.EntityFrameworkCore.Tools installieren
            // 2) 'AddMigration InitalCreate' ausführen

            //  -----  Falls das EF-Core Projekt eine DLL ist (z.B. .NET Standard:) ----
            // 3) Ein .NET Core Projekt (z.B. .NET Core Konsole) hinzufügen
            // 4) Nuget EFCore im Konsolenprojekt installieren + Alle Referenzen auf die DLLS hinzufügen (Domain, Data.EF)
            // 5) Startprojekt in VS: Konsolenprogramm UND PackageManagerConsole-DefaultProjekt (Dropdown-Box): Data.EF

            modelBuilder.Entity<Airport>().Property(x => x.LocInt)
                                          .HasMaxLength(4)
                                          .IsFixedLength()
                                          .IsRequired();
            modelBuilder.Entity<Airport>().Property(x => x.Decode)
                                          .HasMaxLength(200)
                                          .IsRequired();
            modelBuilder.Entity<Airport>().Property(x => x.Iata)
                                          .HasMaxLength(3)
                                          .IsFixedLength();

            modelBuilder.Entity<Airport>().Property(x => x.ModifiedDate)
                                          .IsConcurrencyToken(); // Wenn dieser Wert anders ist, meldet die DB, dass z.B. beim Update/Delete der Datensatz in der zwischenzeit schon verändert wurde

            modelBuilder.Entity<Flight>().Property(x => x.AircraftID)
                                         .HasMaxLength(7)
                                         .IsRequired();
            modelBuilder.Entity<Flight>().Property(x => x.ModifiedDate)
                                         .IsConcurrencyToken();


            modelBuilder.Entity<AircraftType>().Property(x => x.Code)
                                               .HasMaxLength(4)
                                               .IsRequired();
            modelBuilder.Entity<AircraftType>().Property(x => x.Model)
                                               .HasMaxLength(200)
                                               .IsRequired();
            modelBuilder.Entity<AircraftType>().Property(x => x.Manufacturer)
                                               .HasMaxLength(200)
                                               .IsRequired();
            modelBuilder.Entity<AircraftType>().Property(x => x.WTC)
                                               .IsRequired();
            modelBuilder.Entity<AircraftType>().Property(x => x.ModifiedDate)
                                               .IsConcurrencyToken();
        }

        public override int SaveChanges() // Jedes mal wenn der Kontext gespeichert wird !!!
        {
            DateTime now = DateTime.Now; // zwischenspeichern !!!1111elf

            // Im Changetracker schauen, was sich alles verändert hat:
            foreach (var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Modified))
            {
                ((Entity)item.Entity).ModifiedDate = now;
            }
            foreach (var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
            {
                ((Entity)item.Entity).ModifiedDate = now;
                ((Entity)item.Entity).CreationDate = now;
            }
            // Hard-Delete: Setzen wie unten macht aktuell keinen sinn:
            //foreach (var item in context.ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted))
            //{
            //    ((Entity)item.Entity).ModifiedDate = now;
            //    ((Entity)item.Entity).DeletedDate = now;
            //    ((Entity)item.Entity).IsDeleted = true;
            //}



            return base.SaveChanges();
        }
    }
}
