using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using BaleLib.Models.Updates;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace BaleLibTest
{
    public class TextTest : BaseTest
    {

        [Fact]
        public void Json_file_must_deserialized()
        {
            string jsonFile = Utils.ReadFile(JsonPath + "text\\TextMessage.json");
            int updateCount = 2;

            UpdateResult result = Utils.Deserialize<UpdateResult>(jsonFile);

            Assert.NotNull(result);
            Assert.Equal(result.Result.Count, updateCount);
        }

        [Fact]
        public void Should_send_a_text_message_successfully()
        {
            BaleClient client = new BaleClient(Token);
            client.SendTextMessage(new TextMessage()
            {
                ChatId = ChatId,
                Text = "salam"
            });
        }

        [Fact]
        public void Update_message_successfully()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendTextMessage(new TextMessage()
            {
                ChatId = ChatId,
                Text = "salam"
            });


            Response editResponse = client.EditTextMessage(new TextMessage()
            {
                ChatId = ChatId,
                Text = "updated text message"
            }, response.Result.MessageId);


            editResponse.Ok.Should().BeTrue();
            editResponse.Description.Should().BeNull();

        }

        [Fact]
        public void Update_message_must_fail_because_messageId_is_invalid()
        {
            BaleClient client = new BaleClient(Token);
            Response editResponse = client.EditTextMessage(new TextMessage()
            {
                ChatId = ChatId,
                Text = "updated text message"
            }, 1010);


            editResponse.Ok.Should().BeFalse();
            editResponse.Description.Should().NotBeNull();
        }

        [Fact]
        public void Send_a_textMessage_with_inlineKeyboard()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendTextMessage(new TextMessage()
            {
                ChatId = ChatId,
                Text = "click on buttons",
                ReplyMarkup = new ReplyKeyboard()
                {
                    InlineKeyboard = new List<List<InlineKeyboardItem>>()
                    {
                        new List<InlineKeyboardItem>()
                        {
                            new InlineKeyboardItem("button one"),
                            new InlineKeyboardItem("button two")
                        }
                    }
                }
            });

            response.Ok.Should().BeTrue();
            response.Result.Should().NotBeNull();
        }

        [Fact]
        public void Send_a_textMessage_with_inlineKeyboard_via_keboard_builder()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendTextMessage(new TextMessage()
            {
                ChatId = ChatId,
                Text = "click on buttons",
                ReplyMarkup = ReplyKeyboard.Create().AddButton("button one").AddButton("button two")
                    .AddButton("button three").Build()
            });

            response.Ok.Should().BeTrue();
            response.Result.Should().NotBeNull();
        }

        [Fact]
        public void Send_message_should_fail_because_token_is_invalid()
        {
            BaleClient client = new BaleClient("invalid token");
            Response response = client.SendTextMessage(new TextMessage()
            {
                ChatId = ChatId,
                Text = "good by world!",
            });

            response.Ok.Should().BeFalse();
            response.Errorcode.Should().Be(401);
        }
    }
}
