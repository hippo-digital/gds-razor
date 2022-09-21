using Hippo.GdsRazor.Test.Controllers;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.SkipLink;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("SkipLink");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersText()
    {
        var response = await Navigate("SkipLink" ,nameof(SkipLinkController.Default));
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.Equal("Skip to main content", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersDefaultHref()
    {
        var response = await Navigate("SkipLink" ,nameof(SkipLinkController.NoHref));
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.Equal("#content", component!.Attributes["href"]?.Value);
    }
}
