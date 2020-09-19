namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

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
            builder.Entity<Diagnose>(entity =>
            {
                entity
                    .HasOne(p => p.Patient)
                    .WithMany(d => d.Diagnoses)
                    .HasForeignKey(k => k.PatientId);
            });

            builder.Entity<Medicament>(entity =>
            {
                entity
                    .HasMany(p => p.Prescriptions)
                    .WithOne(m => m.Medicament)
                    .HasForeignKey(k => k.MedicamentId);
            });

            builder.Entity<Patient>(entity =>
            {
                entity
                    .HasMany(p => p.Prescriptions)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(k => k.PatientId);

                entity
                    .HasMany(p => p.Diagnoses)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(k => k.DiagnoseId);

                entity
                    .HasMany(p => p.Visitations)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(k => k.VisitationId);
            });

            builder.Entity<PatientMedicament>(entity =>
            {
                entity
                    .HasKey(k => new { k.PatientId, k.MedicamentId });

                entity
                    .HasOne(p => p.Patient)
                    .WithMany(pm => pm.Prescriptions)
                    .HasForeignKey(k => k.PatientId);

                entity
                    .HasOne(p => p.Medicament)
                    .WithMany(pm => pm.Prescriptions)
                    .HasForeignKey(k => k.MedicamentId);
            });

            builder.Entity<Visitation>(entity =>
            {
                entity
                    .HasOne(p => p.Patient)
                    .WithMany(v => v.Visitations)
                    .HasForeignKey(k => k.PatientId);

                entity
                    .HasOne(d => d.Doctor)
                    .WithMany(v => v.Visitations)
                    .HasForeignKey(k => k.DoctorId);
            });
        }
    }
}
