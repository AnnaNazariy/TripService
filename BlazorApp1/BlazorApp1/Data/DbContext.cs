using Microsoft.EntityFrameworkCore;
using BlazorApp1.Models;

namespace BlazorApp1.Data
{
    public class TripServiceDbContext : DbContext
    {
        public TripServiceDbContext(DbContextOptions<TripServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTrip> AccountsTrips { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountTrip>()
                .HasKey(at => new { at.AccountId, at.TripId });

            modelBuilder.Entity<AccountTrip>()
                .HasOne(at => at.Account)
                .WithMany(a => a.AccountsTrips)
                .HasForeignKey(at => at.AccountId);

            modelBuilder.Entity<AccountTrip>()
                .HasOne(at => at.Trip)
                .WithMany(t => t.AccountsTrips)
                .HasForeignKey(at => at.TripId);

            modelBuilder.Entity<Hotel>()
                .Property(h => h.BaseRate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Room>()
                .Property(r => r.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Review>()
                .Property(r => r.Comments).IsRequired();
            modelBuilder.Entity<Review>()
                .Property(r => r.UserName).IsRequired();
            modelBuilder.Entity<Review>()
                .Property(r => r.Rating).HasDefaultValue(1).HasColumnType("int");
            modelBuilder.Entity<Review>()
                .Property(r => r.Date).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<City>()
                .HasIndex(c => c.Name);

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.City)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.CityId)
                .IsRequired();
        }
    }
}
