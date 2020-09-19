namespace Cinema.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class CinemaContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Projection> Projections { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Ticket> Tickets { get; set; }


        public CinemaContext()  { }

        public CinemaContext(DbContextOptions options)
            : base(options)   { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ticket>(ticket =>
            {
                ticket
                    .HasOne(t => t.Customer)
                    .WithMany(c => c.Tickets)
                    .HasForeignKey(t => t.CustomerId);

                ticket
                    .HasOne(t => t.Projection)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(t => t.ProjectionId);
            });

            builder.Entity<Seat>(seat =>
            {
                seat
                    .HasOne(s => s.Hall)
                    .WithMany(h => h.Seats)
                    .HasForeignKey(s => s.HallId);
            });

            builder.Entity<Projection>(projection =>
            {
                projection
                    .HasOne(p => p.Movie)
                    .WithMany(m => m.Projections)
                    .HasForeignKey(p => p.MovieId);

                projection
                    .HasOne(p => p.Hall)
                    .WithMany(h => h.Projections)
                    .HasForeignKey(p => p.HallId);
            });
        }
    }
}