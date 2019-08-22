using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class VideoTest : BaseTest
    {
        [Fact]
        public void Send_video_successfully()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendVideoAsync(new VideoMessage()
            {
                Caption = "video caption",
                ChatId = ChatId,
                Video = Utils.ToBytes(FilePath + "video.mp4"),
                Name = "docFileName"
            }).Result;

            response.Ok.Should().BeTrue();
            response.Result.Video.Should().NotBeNull();
        }
    }
}
