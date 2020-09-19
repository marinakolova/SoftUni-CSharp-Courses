namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SoftJailDbContext : DbContext
	{
        public DbSet<Cell> Cells { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Mail> Mails { get; set; }

        public DbSet<Officer> Officers { get; set; }

        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        public DbSet<Prisoner> Prisoners { get; set; }
        

        public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

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
            builder.Entity<OfficerPrisoner>(officerPrisoner =>
            {
                officerPrisoner.HasKey(k => new {k.OfficerId, k.PrisonerId});

                officerPrisoner
                    .HasOne(op => op.Officer)
                    .WithMany(o => o.OfficerPrisoners)
                    .HasForeignKey(op => op.OfficerId);

                officerPrisoner
                    .HasOne(op => op.Prisoner)
                    .WithMany(p => p.PrisonerOfficers)
                    .HasForeignKey(op => op.PrisonerId);
            });

            builder.Entity<Mail>(mail =>
            {
                mail
                    .HasOne(m => m.Prisoner)
                    .WithMany(p => p.Mails)
                    .HasForeignKey(m => m.PrisonerId);
            });

            builder.Entity<Cell>(cell =>
            {
                cell
                    .HasOne(c => c.Department)
                    .WithMany(d => d.Cells)
                    .HasForeignKey(c => c.DepartmentId);

                cell
                    .HasMany(c => c.Prisoners)
                    .WithOne(p => p.Cell)
                    .HasForeignKey(p => p.CellId);
            });
        }
	}
}