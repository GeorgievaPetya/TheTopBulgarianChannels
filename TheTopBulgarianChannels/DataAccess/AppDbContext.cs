namespace TheTopBulgarianChannels.DataAccess
{
    using TheTopBulgarianChannels.DataModels;
    using Microsoft.EntityFrameworkCore;  
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<YouTubeChannel> YouTubeCnannels { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}
