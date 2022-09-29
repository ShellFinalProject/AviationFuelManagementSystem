using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AFMS.Models
{
    public partial class afmsDataBaseContext : DbContext
    {
        public afmsDataBaseContext()
        {
        }

        public afmsDataBaseContext(DbContextOptions<afmsDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminTable> AdminTable { get; set; }
        public virtual DbSet<ClientTable> ClientTable { get; set; }
        public virtual DbSet<FlightDetails> FlightDetails { get; set; }
        public virtual DbSet<FuelList> FuelList { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLlocaldb;Database=afmsDataBase;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminTable>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__adminTab__AD0500869D787965");

                entity.ToTable("adminTable");

                entity.HasIndex(e => e.AdminName)
                    .HasName("UQ__adminTab__330679FE6FCFF9F9")
                    .IsUnique();

                entity.HasIndex(e => e.Password)
                    .HasName("UQ__adminTab__87909B150F141C54")
                    .IsUnique();

                entity.Property(e => e.AdminId).HasColumnName("adminID");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasColumnName("adminName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientTable>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PK__clientTa__81A2CB8192557476");

                entity.ToTable("clientTable");

                entity.HasIndex(e => e.ClientName)
                    .HasName("UQ__clientTa__F7B8CD45C6DCAAE1")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__clientTa__A9D1053449826E70")
                    .IsUnique();

                entity.HasIndex(e => e.Gstin)
                    .HasName("UQ__clientTa__0604E65FE18794BF")
                    .IsUnique();

                entity.HasIndex(e => e.Password)
                    .HasName("UQ__clientTa__87909B15651323F1")
                    .IsUnique();

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("clientName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gstin)
                    .IsRequired()
                    .HasColumnName("GSTIN")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LoyaltyPoints).HasColumnName("loyaltyPoints");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlightDetails>(entity =>
            {
                entity.HasKey(e => e.FlightNo)
                    .HasName("PK__flightDe__0E01AFB9B87EC372");

                entity.ToTable("flightDetails");

                entity.HasIndex(e => e.ClientId)
                    .HasName("UQ__flightDe__81A2CB80E4AB0491")
                    .IsUnique();

                entity.Property(e => e.FlightNo)
                    .HasColumnName("flightNo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AircraftType)
                    .IsRequired()
                    .HasColumnName("aircraftType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.FlightDetails)
                    .HasForeignKey<FlightDetails>(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__flightDet__clien__2E1BDC42");
            });

            modelBuilder.Entity<FuelList>(entity =>
            {
                entity.HasKey(e => e.FuelId)
                    .HasName("PK__fuelList__64E043E418892F0E");

                entity.ToTable("fuelList");

                entity.HasIndex(e => e.FuelName)
                    .HasName("UQ__fuelList__3726811833A99E08")
                    .IsUnique();

                entity.Property(e => e.FuelId).HasColumnName("fuelID");

                entity.Property(e => e.FuelCurrentPrice).HasColumnName("fuelCurrentPrice");

                entity.Property(e => e.FuelName)
                    .IsRequired()
                    .HasColumnName("fuelName")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FuelPrevCost).HasColumnName("fuelPrevCost");

                entity.Property(e => e.LastUpdated).HasColumnName("lastUpdated");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__orderDet__0809337D4E4A6550");

                entity.ToTable("orderDetails");

                entity.HasIndex(e => e.OrderPlaceDate)
                    .HasName("UQ__orderDet__7799D7E538D32D5F")
                    .IsUnique();

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.FlightNo)
                    .IsRequired()
                    .HasColumnName("flightNo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FuelAmt).HasColumnName("fuelAmt");

                entity.Property(e => e.FuelId).HasColumnName("fuelID");

                entity.Property(e => e.OrderDeliveryDate)
                    .HasColumnName("orderDeliveryDate")
                    .HasColumnType("date");

                entity.Property(e => e.OrderPlaceDate)
                    .HasColumnName("orderPlaceDate")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderDeta__clien__49C3F6B7");

                entity.HasOne(d => d.FlightNoNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.FlightNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderDeta__fligh__4AB81AF0");

                entity.HasOne(d => d.Fuel)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.FuelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderDeta__fuelI__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
