using AngleSharp.Html.Dom;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.SkipLink;

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
        var response = await Navigate("/SkipLink/Default");
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.Equal("Skip to main content", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersDefaultHref()
    {
        var response = await Navigate("/SkipLink/NoHref");
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.Equal("#content", component!.Attributes["href"]?.Value);
    }
}
