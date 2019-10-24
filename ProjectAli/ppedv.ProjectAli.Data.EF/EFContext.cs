using Microsoft.EntityFrameworkCore;
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
        // Microsoft.EntityFrameworkCore.SQLServer

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
            modelBuilder.Entity<Airport>().Property(x => x.Location)
                                          .IsRequired();

            modelBuilder.Entity<Flight>().Property(x => x.Departure)
                                         .IsRequired();
            modelBuilder.Entity<Flight>().Property(x => x.Destination)
                                         .IsRequired();
            modelBuilder.Entity<Flight>().Property(x => x.Duration)
                                         .IsRequired();
            modelBuilder.Entity<Flight>().Property(x => x.AircraftID)
                                         .HasMaxLength(7)
                                         .IsRequired();
            modelBuilder.Entity<Flight>().Property(x => x.AircraftType)
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
