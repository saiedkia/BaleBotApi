using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class InvoiceTest : BaseTest
    {
        [Fact]
        public void Send_invoice()
        {
            BaleClient client = new BaleClient(Token);
            Response response = client.SendInvoice(new InvoiceMessage(ChatId, "paloadData", "pizza chicago", "pizza chicago with special souce", "my token", new Price("pizza chicago", 300_000)));
                    
            response.Ok.Should().BeTrue();
            response.Result.Invoice.Should().NotBeNull();
        }
    }
}
