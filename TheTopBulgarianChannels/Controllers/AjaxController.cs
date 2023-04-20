namespace TheTopBulgarianChannels.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using TheTopBulgarianChannels.DataAccess;
    using TheTopBulgarianChannels.DataModels;
    public class AjaxController : Controller
    {
       
        private readonly AppDbContext _context;        
        private static Random Randomrnd = new Random();

        public AjaxController( AppDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetRandomCarImage()
        {
            var youTubeChannel = _context.YouTubeChannels.ToList();

            var nextYouTubeIndex = Randomrnd.Next(0, youTubeChannel.Count);

            return Ok(new
            {
                name = youTubeChannel[nextYouTubeIndex].ChannelName
            }) ;
        }

    }
}
