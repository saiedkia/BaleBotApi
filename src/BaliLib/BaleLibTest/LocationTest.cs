using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class LocationTest : BaseTest
    {
        [Fact]
        public void Send_location()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendLocation(new LocationMessage()
            {
                ChatId = ChatId,
                Latitude = 35.73122955392002,
                Longitude = 51.41714821748457
            });


            response.Ok.Should().BeTrue();
            response.Result.Location.Should().NotBeNull();
        }
    }
}
