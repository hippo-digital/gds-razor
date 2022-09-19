using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.CharacterCount;

public class ThresholdTests : ClientBase<Startup>
{
    public ThresholdTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HidesTheCountToStartWith()
    {
        var response = await Navigate("/CharacterCount/WithThreshold");
        var component = response.QuerySelector(".govuk-character-count");

        Assert.Equal("75", component?.Attributes["data-threshold"]?.Value);
    }
}
