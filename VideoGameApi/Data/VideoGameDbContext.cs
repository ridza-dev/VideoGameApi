using Microsoft.EntityFrameworkCore;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options): DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoGame>().HasData(
                    new VideoGame
                    {
                        Id = 1,
                        Title = "Spired Man",
                        Platform = "{S5",
                        Developer = "Insomniac Games",
                        Publisher = ""
                    },
            new VideoGame
            {
                Id = 2,
                Title = "Zelda",
                Platform = "Nintendo",
                Developer = "Nintendo",
                Publisher = "Nintendo"
            },
            new VideoGame
            {
                Id = 3,
                Title = "Cyberpunk",
                Platform = "PC",
                Developer = "CD project",
                Publisher = "CD project"
            });
        }
    }
}
