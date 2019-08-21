using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class DocumentTest : BaseTest
    {
        [Fact]
        public void Send_document_successfully()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendDocument(new DocumentMessage()
            {
                Caption = "document file caption",
                ChatId = ChatId,
                Document = Utils.ToBytes(FilePath + "document.pdf"),
                Name = "docFileName"
            });

            response.Ok.Should().BeTrue();
            response.Result.Document.Should().NotBeNull();
        }
    }
}
