namespace VaporStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class VaporStoreDbContext : DbContext
	{
        public DbSet<Card> Cards { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameTag> GameTags { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }


        public VaporStoreDbContext()
		{
		}

		public VaporStoreDbContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<GameTag>(gameTag =>
            {
                gameTag
                    .HasKey(k => new { k.GameId, k.TagId});

                gameTag
                    .HasOne(gt => gt.Game)
                    .WithMany(g => g.GameTags)
                    .HasForeignKey(gt => gt.GameId);

                gameTag
                    .HasOne(gt => gt.Tag)
                    .WithMany(t => t.GameTags)
                    .HasForeignKey(gt => gt.TagId);
            });

            model.Entity<Card>(card =>
            {
                card
                    .HasOne(c => c.User)
                    .WithMany(u => u.Cards)
                    .HasForeignKey(c => c.UserId);
            });

            model.Entity<Game>(game =>
            {
                game
                    .HasOne(g => g.Developer)
                    .WithMany(d => d.Games)
                    .HasForeignKey(g => g.DeveloperId);

                game
                    .HasOne(g => g.Genre)
                    .WithMany(gen => gen.Games)
                    .HasForeignKey(g => g.GenreId);
            });

            model.Entity<Purchase>(purchase =>
            {
                purchase
                    .HasOne(p => p.Card)
                    .WithMany(c => c.Purchases)
                    .HasForeignKey(p => p.CardId);

                purchase
                    .HasOne(p => p.Game)
                    .WithMany(g => g.Purchases)
                    .HasForeignKey(p => p.GameId);
            });
        }
	}
}