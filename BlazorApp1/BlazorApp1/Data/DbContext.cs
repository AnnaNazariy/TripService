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

            // Налаштування для таблиці AccountTrip
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

            // Налаштування для властивостей BaseRate та Price
            modelBuilder.Entity<Hotel>()
                .Property(h => h.BaseRate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Room>()
                .Property(r => r.Price)
                .HasColumnType("decimal(18,2)");

            // Налаштування для моделі Review
            modelBuilder.Entity<Review>()
                .Property(r => r.Comments).IsRequired();
            modelBuilder.Entity<Review>()
                .Property(r => r.UserName).IsRequired();
            modelBuilder.Entity<Review>()
                .Property(r => r.Rating).HasDefaultValue(1).HasColumnType("int");
            modelBuilder.Entity<Review>()
                .Property(r => r.Date).HasDefaultValueSql("GETDATE()");

            // Приклад індексу для колонки Name в таблиці Cities
            modelBuilder.Entity<City>()
                .HasIndex(c => c.Name);

            // Приклад унікального обмеження для поля Email в таблиці Accounts
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Email)
                .IsUnique();

            // Приклад налаштування зовнішнього ключа для таблиці Rooms
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Приклад налаштування зовнішнього ключа для таблиці Hotels
            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.City)  // навігаційна властивість
                .WithMany(c => c.Hotels) // зворотний зв'язок
                .HasForeignKey(h => h.CityId)  // зовнішній ключ
                .IsRequired();       // обов'язковий зв'язок
        }
    }
}
