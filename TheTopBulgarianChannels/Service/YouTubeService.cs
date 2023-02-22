namespace TheTopBulgarianChannels.Service
{
    using Google.Apis.Services;
    using System.Collections.Generic;
    using System.Linq;
    using TheTopBulgarianChannels.DataAccess;
    using TheTopBulgarianChannels.DataModels;
  

    public class YouTubeService : IYouTubeService   
    {
       
        private readonly AppDbContext db;
        public YouTubeService(AppDbContext db)
        {
            this.db = db;
        }

        public List<YouTubeChannel> GetAll() => this.db.YouTubeChannels.OrderByDescending(y => y.Subscribers).ToList();
        //public List<YouTubeChannel> GetAll() => this.db.YouTubeChannels.ToList();
        
        
    }
}
