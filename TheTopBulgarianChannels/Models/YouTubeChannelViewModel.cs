namespace TheTopBulgarianChannels.Models
{
    using TheTopBulgarianChannels.DataModels;
    public class YouTubeChannelViewModel
    {
        public int Id { get; set; }

        public string ChannelName { get; set; }

        public int Subscribers { get; set; }

        public long Views { get; set; }

        public string ChannelUrl { get; set; }

        public Category Category { get; set; }

        public Country Country { get; set; }
    }
}
