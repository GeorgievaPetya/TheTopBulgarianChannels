using Microsoft.EntityFrameworkCore;
using TheTopBulgarianChannels.Models;
namespace TheTopBulgarianChannels.DataAccess
{
    using TheTopBulgarianChannels.DataModels;
    using Microsoft.EntityFrameworkCore;  
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<YouTubeChannel> YouTubeChannels { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Instagram> Instagram { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.YouTubeChannels)
                .WithOne(y => y.Category);

            modelBuilder.Entity<Country>()
               .HasMany(c => c.YouTubeChannels)
               .WithOne(y => y.Country);
        }

       public DbSet<TheTopBulgarianChannels.Models.YouTubeChannelViewModel> YouTubeChannelViewModel { get; set; }
    
    }
}
