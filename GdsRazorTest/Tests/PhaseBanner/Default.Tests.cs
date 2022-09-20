using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.PhaseBanner;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("PhaseBanner");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void AllowsAdditionalClassesToBeAddedToTheComponent()
    {
        var response = await Navigate("/PhaseBanner/Classes");
        var component = response.QuerySelector(".govuk-phase-banner");

        Assert.Contains("extra-class", component!.ClassList);
        Assert.Contains("one-more-class", component.ClassList);
    }

    [Fact]
    public async void RendersBannerText()
    {
        var response = await Navigate("/PhaseBanner/Text");
        var component = response.QuerySelector(".govuk-phase-banner__text");

        Assert.Equal("This is a new service – your feedback will help us to improve it", component!.TextContent.Trim());
    }

    [Fact]
    public async void AllowsBodyTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("/PhaseBanner/HtmlAsText");
        var component = response.QuerySelector(".govuk-phase-banner__text");

        Assert.Equal("This is a new service - your &lt;a href=\"#\" class=\"govuk-link\"&gt;feedback&lt;/a&gt; will help us to improve it.", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsBodyHtmlToBePassedUnescaped()
    {
        var response = await Navigate("/PhaseBanner/Default");
        var component = response.QuerySelector(".govuk-phase-banner__text");

        Assert.Equal("This is a new service - your <a href=\"#\" class=\"govuk-link\">feedback</a> will help us to improve it.", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsAdditionalAttributesToBeAddedToTheComponent()
    {
        var response = await Navigate("/PhaseBanner/Attributes");
        var component = response.QuerySelector(".govuk-phase-banner");

        Assert.Equal("foo", component!.Attributes["first-attribute"]?.Value);
        Assert.Equal("bar", component!.Attributes["second-attribute"]?.Value);
    }
}
