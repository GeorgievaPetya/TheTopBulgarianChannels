namespace TheTopBulgarianChannels.Controllers
{
    using Google.Apis.YouTube.v3.Data;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Channels;
    using System.Threading.Tasks;
    using TheTopBulgarianChannels.DataModels;
    using TheTopBulgarianChannels.Models;
    using TheTopBulgarianChannels.Service;
  

    public class HomeController : Controller
    {
        private readonly IYouTubeService youTubeService;
        static readonly HttpClient client = new HttpClient();

        public HomeController(IYouTubeService youTubeService)
        {
            this.youTubeService = youTubeService;
        }
        public IActionResult Index()

        {
            var youTubeChannels = this.youTubeService.GetAll();
            var model = new YouTubeChannelViewModelList
            {
                List = GetYouTubeChannelViewModel(youTubeChannels)

            };
            return View(model);       
        }
       
       /* public ActionResult YouTube()
        {

            var youTubeChannels = this.youTubeService.GetAll();
            var model = new YouTubeChannelViewModelList
            {
                List = GetYouTubeChannelViewModel(youTubeChannels)

            };
            return View(model);
        }*/
  
        [HttpGet]
        public IActionResult AddYouTubeChannel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddYouTubeChannel(YouTubeChannelViewModel youTubeChannel)
        {
            this.youTubeService.Add(GetYouTubeDataModel(youTubeChannel));
            
            return RedirectToAction("Index");
        }

        private YouTubeChannel GetYouTubeDataModel(YouTubeChannelViewModel youTubeChannel)
        {
            

            return new YouTubeChannel
            {
                Id = youTubeChannel.Id,
                ChannelName = youTubeChannel.ChannelName,
                //ChannelUrl = youTubeChannel.ChannelUrl,
                Subscribers = youTubeChannel.Subscribers,
                Views = youTubeChannel.Views,
                Category = youTubeChannel.Category,
                //Country = youTubeChannel.Country,
                //ChannelHandle = youTubeChannel.ChannelHandle,
                ChannelId = youTubeChannel.ChannelId
            };
        }

        /*private async Task<YouTubeChannel> GetYouTubeChannelDataModelAsync()
        {
            try
            {
                using HttpResponseMessage responseChannelId = await client
                  .GetAsync($"https://www.googleapis.com/youtube/v3/search?part=snippet&q={youTubeChannel.ChannelName}type=channel&key=AIzaSyD2pVYifyHpdyqc5115-jc7iqWNkFmiWTc");
                responseChannelId.EnsureSuccessStatusCode();
                string responseBodyChannelInfo = await responseChannelId.Content.ReadAsStringAsync();
                JObject channelIdInfo = JObject.Parse(responseBodyChannelInfo);
                youTubeChannel.ChannelId = (string)channelIdInfo["items"][0]["snippet"]["channelId"];
                using HttpResponseMessage responseStatistik = await client
                  .GetAsync($"https://www.googleapis.com/youtube/v3/channels?part=statistics&id={youTubeChannel.ChannelId}&key=AIzaSyD2pVYifyHpdyqc5115-jc7iqWNkFmiWTc");
                responseStatistik.EnsureSuccessStatusCode();
                string responseBodyStatistikInfo = await responseStatistik.Content.ReadAsStringAsync();
                JObject statistikInfo = JObject.Parse(responseBodyStatistikInfo);
                youTubeChannel.Subscribers = (int)statistikInfo["items"][0]["statistics"]["subscriberCount"];
                youTubeChannel.Views = (long)statistikInfo["items"][0]["statistics"]["viewCount"];
                var videoCount = statistikInfo["items"][0]["statistics"]["videoCount"];
            }
            catch (HttpRequestException e)
            {

                throw;
            }
            return new YouTubeChannel
            {
                Id = youTubeChannel.Id,
                ChannelName = youTubeChannel.ChannelName,
                //ChannelUrl = youTubeChannel.ChannelUrl,
                Subscribers = youTubeChannel.Subscribers,
                Views = youTubeChannel.Views,
                Category = youTubeChannel.Category,
               //Country = youTubeChannel.Country,
               //ChannelHandle = youTubeChannel.ChannelHandle,
                ChannelId = youTubeChannel.ChannelId
            };
        }
        */
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private YouTubeChannelViewModel GetYouTubeChannelViewModel(YouTubeChannel y) => new YouTubeChannelViewModel
        {
            Id = y.Id,
            ChannelName = y.ChannelName,
            ChannelUrl = y.ChannelUrl,
            Subscribers = y.Subscribers,
            Views = y.Views,
            Category = y.Category,
            Country = y.Country,
            ChannelHandle = y.ChannelHandle,
            ChannelId = y.ChannelId
        };

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
