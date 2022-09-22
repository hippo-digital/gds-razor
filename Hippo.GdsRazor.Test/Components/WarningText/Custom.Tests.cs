using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.WarningText;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersClasses()
    {
        var response = await Navigate("WarningText" ,nameof(WarningTextController.Classes));
        var component = response.QuerySelector(".govuk-warning-text");

        Assert.Contains("govuk-warning-text--custom-class", component!.ClassList);
    }

    [Fact]
    public async void RendersCustomAssistiveText()
    {
        var response = await Navigate("WarningText" ,nameof(WarningTextController.IconFallbackTextOnly));
        var component = response.QuerySelector(".govuk-warning-text__assistive");

        Assert.Equal("Some custom fallback text", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersAttributes()
    {
        var response = await Navigate("WarningText" ,nameof(WarningTextController.Attributes));
        var component = response.QuerySelector(".govuk-warning-text");

        Assert.Equal("attribute", component!.Attributes["data-test"]?.Value);
    }
}
