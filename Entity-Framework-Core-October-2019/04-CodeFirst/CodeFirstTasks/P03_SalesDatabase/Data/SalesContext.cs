namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sale>(entity =>
            {
                entity
                    .HasOne(p => p.Product)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(k => k.ProductId);

                entity
                    .HasOne(st => st.Store)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(k => k.StoreId);

                entity
                    .HasOne(c => c.Customer)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(k => k.CustomerId);
            });

            builder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
