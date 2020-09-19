using Microsoft.EntityFrameworkCore;
using SharedTrip.Models;

namespace SharedTrip.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>(entity =>
            {
                entity
                    .HasKey(k => new { k.UserId, k.TripId });

                entity
                    .HasOne(ut => ut.User)
                    .WithMany(u => u.UserTrips)
                    .HasForeignKey(ut => ut.UserId);

                entity
                    .HasOne(ut => ut.Trip)
                    .WithMany(t => t.UserTrips)
                    .HasForeignKey(ut => ut.TripId);
            });
        }
    }
}
