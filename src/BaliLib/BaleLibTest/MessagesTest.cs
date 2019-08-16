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
            Response response = client.SendTextMessage(new TextMessage()
            {
                ChatId = ChatId,
                Text = "should be deleted very soon :)"
            });


            Response<bool> deleteMessageResponse = client.DeleteMessage(ChatId, response.Result.MessageId);


            deleteMessageResponse.Ok.Should().BeTrue();

        }
    }
}
