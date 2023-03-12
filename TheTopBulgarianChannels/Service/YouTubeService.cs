namespace TheTopBulgarianChannels.Service
{
    using Google.Apis.Services;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TheTopBulgarianChannels.DataAccess;
    using TheTopBulgarianChannels.DataModels;


    public class YouTubeService : IYouTubeService
    {
       
        private readonly AppDbContext db;
        private YouTubeChannel youTubeChannel;

        public YouTubeService(AppDbContext db)
        {
            this.db = db;
        }

        public List<YouTubeChannel> GetAll() => this.db.YouTubeChannels.OrderByDescending(y => y.Subscribers).ToList();

        public void Add(YouTubeChannel youTubeChannel)
        {
            var userexist = db.YouTubeChannels.Any(x => x.ChannelName == youTubeChannel.ChannelName);
            if (userexist)
            {
                return;
            }
            else
            {

                this.db.YouTubeChannels.Add(youTubeChannel);
                this.db.SaveChanges();
            }
            
        }



        //public List<YouTubeChannel> GetAll() => this.db.YouTubeChannels.ToList();


    }
}
