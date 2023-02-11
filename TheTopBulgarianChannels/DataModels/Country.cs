namespace TheTopBulgarianChannels.DataModels
{
    using System.Collections.Generic;
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public ICollection<YouTubeChannel> YouTubeChannels { get; set; }
    }
}
