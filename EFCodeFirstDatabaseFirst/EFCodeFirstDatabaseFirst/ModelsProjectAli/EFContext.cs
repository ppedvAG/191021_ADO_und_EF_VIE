using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCodeFirstDatabaseFirst.ModelsProjectAli
{
    public partial class EFContext : DbContext
    {
        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AircraftType> AircraftType { get; set; }
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjectAli_Test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AircraftType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Wtc).HasColumnName("WTC");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Decode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Iata)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.LocInt)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsFixedLength();

                entity.Property(e => e.SupportedWtc).HasColumnName("SupportedWTC");
            });

            modelBuilder.Entity<Flight>(flightEntity =>
            {
                flightEntity.HasIndex(e => e.AircraftTypeId);

                flightEntity.HasIndex(e => e.DepartureId);

                flightEntity.HasIndex(e => e.DestinationId);

                flightEntity.Property(e => e.Id).HasColumnName("ID");

                flightEntity.Property(e => e.AircraftId)
                    .IsRequired()
                    .HasColumnName("AircraftID")
                    .HasMaxLength(7);

                flightEntity.Property(e => e.AircraftTypeId).HasColumnName("AircraftTypeID");

                flightEntity.Property(e => e.DepartureId).HasColumnName("DepartureID");

                flightEntity.Property(e => e.DestinationId).HasColumnName("DestinationID");

                flightEntity.HasOne(d => d.AircraftType)
                    .WithMany(p => p.Flight)
                    .HasForeignKey(d => d.AircraftTypeId);

                flightEntity.HasOne(d => d.Departure)
                    .WithMany(p => p.FlightDeparture)
                    .HasForeignKey(d => d.DepartureId);

                flightEntity.HasOne(d => d.Destination)
                    .WithMany(p => p.FlightDestination)
                    .HasForeignKey(d => d.DestinationId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
