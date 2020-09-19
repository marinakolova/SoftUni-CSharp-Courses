using TeisterMask.Data.Models;

namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;

    public class TeisterMaskContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeTask> EmployeesTasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }

        
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>(employeeTask =>
            {
                employeeTask.HasKey(k => new { k.EmployeeId, k.TaskId});

                employeeTask
                    .HasOne(et => et.Employee)
                    .WithMany(e => e.EmployeesTasks)
                    .HasForeignKey(et => et.EmployeeId);

                employeeTask
                    .HasOne(et => et.Task)
                    .WithMany(t => t.EmployeesTasks)
                    .HasForeignKey(et => et.TaskId);
            });

            modelBuilder.Entity<Task>(task =>
            {
                task
                    .HasOne(t => t.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(t => t.ProjectId);
            });
        }
    }
}