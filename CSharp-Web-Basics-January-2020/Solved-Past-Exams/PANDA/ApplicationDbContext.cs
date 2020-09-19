using Microsoft.EntityFrameworkCore;
using PANDA.Models;

namespace PANDA
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-DTGPHD2G\\SQLEXPRESS;Database=PANDA;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>(entity =>
            {
                entity
                    .HasOne(p => p.Recipient)
                    .WithMany(u => u.Packages)
                    .HasForeignKey(p => p.RecipientId);
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity
                    .HasOne(r => r.Recipient)
                    .WithMany(u => u.Receipts)
                    .HasForeignKey(r => r.RecipientId);

                entity
                    .HasOne(r => r.Package)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(r => r.PackageId);
            });
        }
    }
}
