using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ppedv.ProjectAli.Domain;
using System;
using System.Collections.Generic;
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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjectAli_Produktiv;Trusted_Connection=true;");
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
            modelBuilder.Entity<Flight>().Property(x => x.AircraftID)
                                         .HasMaxLength(7)
                                         .IsRequired();


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
        }
    }
}
