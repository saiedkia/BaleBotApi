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

            Response<List<Update>> response = Utils.Deserialize<Response<List<Update>>>(jsonFile);

            Assert.NotNull(response);
            Assert.Equal(response.Result.Count, updateCount);
        }

        [Fact]
        public void Should_send_a_text_message_successfully()
        {
            BaleClient client = new BaleClient(Token);
            string textMessage = "salam";
            Response response = client.SendTextAsync(new TextMessage()
            {
                ChatId = ChatId,
                Text = textMessage
            }).Result;

            response.Ok.Should().BeTrue();
            response.Result.Text.Should().Be(textMessage);
        }

        [Fact]
        public void Update_message_successfully()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendTextAsync(new TextMessage()
            {
                ChatId = ChatId,
                Text = "salam"
            }).Result;


            Response editResponse = client.EditTextAsync(new TextMessage()
            {
                ChatId = ChatId,
                Text = "updated text message"
            }, response.Result.MessageId).Result;


            editResponse.Ok.Should().BeTrue();
            editResponse.Description.Should().BeNull();

        }

        [Fact]
        public void Update_message_must_fail_because_messageId_is_invalid()
        {
            BaleClient client = new BaleClient(Token);
            Response editResponse = client.EditTextAsync(new TextMessage()
            {
                ChatId = ChatId,
                Text = "updated text message"
            }, 1010).Result;


            editResponse.Ok.Should().BeFalse();
            editResponse.Description.Should().NotBeNull();
        }

        [Fact]
        public void Send_a_textMessage_with_inlineKeyboard()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendTextAsync(new TextMessage()
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
            }).Result;

            response.Ok.Should().BeTrue();
            response.Result.Should().NotBeNull();
        }

        [Fact]
        public void Send_a_textMessage_with_inlineKeyboard_via_keboard_builder()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendTextAsync(new TextMessage()
            {
                ChatId = ChatId,
                Text = "click on buttons",
                ReplyMarkup = ReplyKeyboard.Create().AddButton("button one").AddButton("button two")
                    .AddButton("button three").Build()
            }).Result;

            response.Ok.Should().BeTrue();
            response.Result.Should().NotBeNull();
        }

        [Fact]
        public void Send_message_should_fail_because_token_is_invalid()
        {
            BaleClient client = new BaleClient("invalid token");
            Response response = client.SendTextAsync(new TextMessage()
            {
                ChatId = ChatId,
                Text = "good by world!",
            }).Result;

            response.Ok.Should().BeFalse();
            response.Errorcode.Should().Be(401);
        }
    }
}
