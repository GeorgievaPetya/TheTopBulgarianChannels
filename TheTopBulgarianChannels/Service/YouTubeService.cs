namespace TheTopBulgarianChannels.Service
{
    using TheTopBulgarianChannels.DataAccess;
    public class YouTubeService : IYouTubeService   
    {
        private readonly AppDbContext db;

        public YouTubeService(AppDbContext db)
        {
            this.db = db;
        }
    }
}
