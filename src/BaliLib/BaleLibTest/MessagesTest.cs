using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class MessagesTest : BaseTest
    {
        [Fact]
        public void DeleteMessage_successfully()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendTextAsync(new TextMessage()
            {
                ChatId = ChatId,
                Text = "should be deleted very soon :)"
            }).Result;


            Response<bool> deleteMessageResponse = client.DeleteMessageAsync(ChatId, response.Result.MessageId).Result;


            deleteMessageResponse.Ok.Should().BeTrue();

        }
    }
}
