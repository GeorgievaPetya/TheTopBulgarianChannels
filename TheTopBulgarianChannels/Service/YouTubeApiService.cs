using Google.Apis.Services;

namespace TheTopBulgarianChannels.Service
{
    public class YouTubeApiService : IYouTubeApiService
    {
        private BaseClientService.Initializer initializer;

        public YouTubeApiService(BaseClientService.Initializer initializer)
        {
            this.initializer = initializer;
        }
    }
}
