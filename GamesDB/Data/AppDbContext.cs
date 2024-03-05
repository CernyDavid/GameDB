using Microsoft.EntityFrameworkCore;
using GamesDB.Models;

namespace GamesDB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenres> GameGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>(entity =>
            {
                entity
                    .HasMany(g => g.Genres)
                    .WithMany(g => g.Games)
                    .UsingEntity<GameGenres>();
                entity.HasData(
                    new Game { GameId = 1, Name = "Minecraft", Developers = "Notch", ReleaseDate = new DateOnly(2001, 1, 1) }
                    ); ;

            });
            modelBuilder.Entity<Genre>().HasData(
                 new Genre { GenreId = 1, Name="Survival" }
            );
            modelBuilder.Entity<GameGenres>(entity =>
            {
                entity.HasKey(gg => new { gg.GameId, gg.GenreId });
                entity.HasData(new GameGenres { GenreId = 1, GameId = 1});
            });
        }
    }
}
