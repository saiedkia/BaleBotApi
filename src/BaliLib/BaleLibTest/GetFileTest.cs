using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class GetFileTest : BaseTest
    {
        [Fact]
        public void Get_file_successfully()
        {
            BaleClient client = new BaleClient(Token);
            Response sendPhotoResponse = client.SendPhoto(new PhotoMessage()
            {
                Caption = "image caption",
                ChatId = ChatId,
                Photo = Utils.ToBytes(FilePath + "lolo.png")
            });

            string fileId = sendPhotoResponse.Result.Photo[0].FileId;
            Response<File> response = client.GetFile(fileId);

            response.Ok.Should().BeTrue();
            response.Result.FileId.Should().Be(fileId);
        }

        //[Fact]
        //public void Get_file_should_fail_fileId_isInvalid()
        //{
        //    BaleClient client = new BaleClient(Token);

        //    string fileId = "00000000:3847076836366666666:1";
        //    Response<File> response = client.GetFile(fileId);

        //    response.Ok.Should().BeTrue();
        //    response.Result.FileId.Should().NotBe(fileId);
        //}
    }
}
