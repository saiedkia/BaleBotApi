using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class ContactTest : BaseTest
    {
        [Fact]
        public void Send_contact()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendContact(new ContactMessage()
            {
                ChatId = ChatId,
                FirstName = "contact name",
                LastName = "last name",
                PhoneNumber = "+989121212121"
            }).Result;


            response.Ok.Should().BeTrue();
            response.Result.Contact.Should().NotBeNull();
        }
    }
}
