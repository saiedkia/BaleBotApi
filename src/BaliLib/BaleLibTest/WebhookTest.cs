using BaleLib;
using BaleLib.Models;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class WebhookTest : BaseTest
    {
        [Fact]
        public void Should_set_webHook_successfully()
        {
            BaleClient client = new BaleClient(Token);
            string sampleHook = "https://myhook.com";

            Response<bool> response = client.SetWebhookAsync(sampleHook).Result;
            response.Ok.Should().BeTrue();
            response.Result.Should().BeTrue();
            response.Description.Should().BeNull();
        }

        [Fact]
        public void Should_set_webHook_fail_because_url_is_not_secure()
        {
            BaleClient client = new BaleClient(Token);
            string sampleHook = "http://myhook.com";

            Response<bool> response = client.SetWebhookAsync(sampleHook).Result;
            response.Ok.Should().BeFalse();
            response.Result.Should().BeFalse();
            response.Description.Should().NotBeNull();
        }

        [Fact]
        public void deleteWebhook()
        {
            BaleClient client = new BaleClient(Token);

            Response<bool> response = client.DeleteWebHook();


            response.Ok.Should().BeTrue();
            response.Result.Should().BeTrue();
            response.Description.Should().BeNull();
        }
    }
}
