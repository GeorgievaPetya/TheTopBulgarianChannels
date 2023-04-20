using NUnit.Framework;
using TheTopBulgarianChannels.DataModels;

namespace TheTopBulgarianChannelsTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_YouTubeChannelCreate()
        {
            var youtubeChannel = new YouTubeChannel();

,            Assert.That(() => { new YouTubeChannel(20,20,20); },
                Throws.Exception.With.Message.EqualTo("Invalid id lenght : 8"));
        }
                
        }
    }
}