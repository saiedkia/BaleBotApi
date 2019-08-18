using BaleLib;
using BaleLib.Models;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class GetChatTest : BaseTest
    {

        [Fact]
        public void Get_chat_detail()
        {
            BaleClient client = new BaleClient(Token);
            Response<Chat> response = client.GetChat(ChatId);

            response.Ok.Should().BeTrue();
            response.Result.Should().NotBeNull();
            response.Result.Id.Should().Be(ChatId);
        }
    }
}
