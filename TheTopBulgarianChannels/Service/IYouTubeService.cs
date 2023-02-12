namespace TheTopBulgarianChannels.Service
{
    using System.Collections.Generic;
    using TheTopBulgarianChannels.DataModels;
    public interface IYouTubeService
    {
        List<YouTubeChannel> GetAll();
    }
}
