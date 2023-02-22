namespace TheTopBulgarianChannels.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Diagnostics;
    using TheTopBulgarianChannels.DataModels;
    using TheTopBulgarianChannels.Models;
    using TheTopBulgarianChannels.Service;

    public class HomeController : Controller
    {
        private readonly IYouTubeService youTubeService;

        public HomeController(IYouTubeService youTubeService)
        {
            this.youTubeService = youTubeService;
        }

        
        public IActionResult Index()
        {
            var youTubeChannels = this.youTubeService.GetAll();

            var model = new YouTubeChannelViewModelList
            {
                List = GetYouTubeChannelViewModel(youTubeChannels),
              
            };

            return View(model);
            

        }
     

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private YouTubeChannel GetYouTubeChannelDataModel(YouTubeChannelViewModel youtubechannel)
        {
            return new YouTubeChannel
            {
                Id = youtubechannel.Id,
                ChannelName = youtubechannel.ChannelName,
                ChannelUrl = youtubechannel.ChannelUrl,
                Subscribers = youtubechannel.Subscribers,
                Views = youtubechannel.Views,
                Category = youtubechannel.Category,
                Country = youtubechannel.Country,
                ChannelHandle = youtubechannel.ChannelHandle,
                ChannelId = youtubechannel.ChannelId
            };
        }

        private YouTubeChannelViewModel GetYouTubeChannelViewModel(YouTubeChannel y)
        {
            
            return new YouTubeChannelViewModel
            {
                Id = y.Id,
                ChannelName = y.ChannelName,
                ChannelUrl = y.ChannelUrl,
                Subscribers = y.Subscribers,
                Views = y.Views,
                Category = y.Category,
                Country = y.Country,
                ChannelHandle = y.ChannelHandle,
                ChannelId= y.ChannelId
            };
        }

        private List<YouTubeChannelViewModel> GetYouTubeChannelViewModel(List<YouTubeChannel> source)
        {
            var youTubeChannels = new List<YouTubeChannelViewModel>();

            foreach (var y in source)
            {
                youTubeChannels.Add(GetYouTubeChannelViewModel(y));
            }

            return youTubeChannels;
        }
    }
}
