﻿namespace TheTopBulgarianChannels.Models
{
    using System.Collections.Generic;
    using TheTopBulgarianChannels.DataModels;
    public class YouTubeChannelViewModel
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int Subscribers { get; set; }
        public long Views { get; set; }
        public int Videos { get; set; }
        public string ChannelUrl { get; set; }
        public string ChannelId { get; set; }
        public string ChannelHandle { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Country Country { get; set; }
        
    }
}
