using BaleLib;
using BaleLib.Models.Updates;
using FluentAssertions;
using Xunit;

namespace BaleLibTest
{
    public class GetUpdatesTest : BaseTest
    {
        [Fact]
        public void Should_get_updates_successfully_and_count_must_be_greater_than_zero()
        {
            BaleClient client = new BaleClient(Token);
            UpdateResult updateResult = client.GetUpdates();

            updateResult.Ok.Should().BeTrue();
            updateResult.Result.Count.Should().BeGreaterThan(0);
        }
    }
}
