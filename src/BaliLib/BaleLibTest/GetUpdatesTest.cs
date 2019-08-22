using BaleLib;
using BaleLib.Models;
using BaleLib.Models.Updates;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace BaleLibTest
{
    public class GetUpdatesTest : BaseTest
    {
        [Fact]
        public void Should_get_updates_successfully_and_count_must_be_greater_than_zero()
        {
            BaleClient client = new BaleClient(Token);
            Response<List<Update>> updateResult = client.GetUpdatesAsync().Result;

            updateResult.Ok.Should().BeTrue();
            updateResult.Result.Count.Should().BeGreaterThan(0);
        }
    }
}
