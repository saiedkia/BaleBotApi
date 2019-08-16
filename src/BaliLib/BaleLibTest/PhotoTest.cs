using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using BaleLib.Models.Updates;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class PhotoTest : BaseTest
    {
        [Fact]
        public void Deserialize_image_json_file()
        {
            string jsonFile = Utils.ReadFile(JsonPath + "file\\photo.json");
            int messagesCount = 1;
            int photosCount = 1;

            UpdateResult updateResult = Utils.Deserialize<UpdateResult>(jsonFile);

            Assert.NotNull(updateResult);
            Assert.True(updateResult.Result.Count == messagesCount);
            Assert.True(updateResult.Result[0].Message.Photo.Count == photosCount);
        }


        [Fact]
        public void Deserialize_image_json_file_array()
        {
            string jsonFile = Utils.ReadFile(JsonPath + "file\\photoArray.json");
            int messagesCount = 1;
            int photosCount = 2;

            UpdateResult updateResult = Utils.Deserialize<UpdateResult>(jsonFile);

            Assert.NotNull(updateResult);
            Assert.True(updateResult.Result.Count == messagesCount);
            Assert.True(updateResult.Result[0].Message.Photo.Count == photosCount);
        }


        [Fact]
        public void Deserialize_image_json_file_messagePhotoArray()
        {
            string jsonFile = Utils.ReadFile(JsonPath + "file\\messagephotoArray.json");
            int messagesCount = 2;
            int photosCount = 2;

            UpdateResult updateResult = Utils.Deserialize<UpdateResult>(jsonFile);

            Assert.NotNull(updateResult);
            Assert.True(updateResult.Result.Count == messagesCount);
            Assert.True(updateResult.Result[0].Message.Photo.Count == photosCount);
        }

        [Fact]
        public void Send_photo_successfully()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendPhoto(new PhotoMessage()
            {
                Caption = "image caption",
                ChatId = ChatId,
                Photo = Utils.ToBytes(FilePath + "lolo.png")
            });

            response.Ok.Should().BeTrue();
            response.Result.Photo.Count.Should().Be(1);
        }
    }
}
