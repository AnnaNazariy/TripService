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
        }
    }
}
