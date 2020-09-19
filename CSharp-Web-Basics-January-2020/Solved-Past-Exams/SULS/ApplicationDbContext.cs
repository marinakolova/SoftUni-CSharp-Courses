using Microsoft.EntityFrameworkCore;
using SULS.Models;

namespace SULS
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-DTGPHD2G\\SQLEXPRESS;Database=SULS;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Submission>(entity =>
            {
                entity
                    .HasOne(s => s.Problem)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(s => s.ProblemId);

                entity
                    .HasOne(s => s.User)
                    .WithMany(u => u.Submissions)
                    .HasForeignKey(s => s.UserId);
            });
        }
    }
}
