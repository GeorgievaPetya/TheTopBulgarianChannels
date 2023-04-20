namespace TheTopBulgarianChannels.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheTopBulgarianChannels.DataModels;
    public interface IYouTubeService
    {
        // TO DO
        List<YouTubeChannel> GetAll();

        void Add(YouTubeChannel youTubeChannel);
      
        //Task<YouTubeChannel> AddAsync(Task<YouTubeChannel> youTubeChannel);

    }
}
