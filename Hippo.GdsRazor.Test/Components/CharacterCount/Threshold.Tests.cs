using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CharacterCount;

public class ThresholdTests : ClientBase<Startup>
{
    public ThresholdTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HidesTheCountToStartWith()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.WithThreshold));
        var component = response.QuerySelector(".govuk-character-count");

        Assert.Equal("75", component?.GetAttribute("data-threshold"));
    }
}
