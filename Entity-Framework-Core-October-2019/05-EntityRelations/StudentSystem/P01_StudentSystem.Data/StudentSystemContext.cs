namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity
                    .HasKey(k => new { k.StudentId, k.CourseId });

                entity
                    .HasOne(s => s.Student)
                    .WithMany(c => c.CourseEnrollments)
                    .HasForeignKey(s => s.StudentId);

                entity
                    .HasOne(c => c.Course)
                    .WithMany(s => s.StudentsEnrolled)
                    .HasForeignKey(c => c.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity
                    .HasOne(s => s.Student)
                    .WithMany(h => h.HomeworkSubmissions)
                    .HasForeignKey(s => s.StudentId);

                entity
                    .HasOne(c => c.Course)
                    .WithMany(h => h.HomeworkSubmissions)
                    .HasForeignKey(c => c.CourseId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity
                    .HasOne(c => c.Course)
                    .WithMany(r => r.Resources)
                    .HasForeignKey(c => c.CourseId);
            });
        }
    }
}
