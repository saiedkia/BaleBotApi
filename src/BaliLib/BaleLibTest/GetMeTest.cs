using BaleLib;
using BaleLib.Models;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class GetMeTest : BaseTest
    {
        [Fact]
        public void GetMe()
        {
            BaleClient client = new BaleClient(Token);
            Response<From> response = client.GetMe();

            response.Ok.Should().BeTrue();
            response.Result.Should().NotBeNull();
            response.Result.IsBot.Should().BeTrue();

        }
    }
}
