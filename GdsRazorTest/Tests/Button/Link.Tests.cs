using AngleSharp.Html.Dom;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.Button;

public class LinkTests : ClientBase<Startup>
{
    public LinkTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithAnchorHrefAndAnAccessibleRoleOfButton()
    {
        var response = await Navigate("/Button/ExplicitLink");
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
        Assert.Equal("/", component.Attributes["href"].Value);
        Assert.Equal("button", component.Attributes["role"].Value);
        Assert.Equal("Continue", component.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithHashHrefIfNoHrefPassed()
    {
        var response = await Navigate("/Button/NoHref");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("#", component.Attributes["href"].Value);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("/Button/LinkAttributes");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("example-id", component.Attributes["aria-controls"].Value);
        Assert.Equal("123", component.Attributes["data-tracking-dimension"].Value);
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("/Button/LinkClasses");
        var component = response.QuerySelector(".govuk-button");

        Assert.Contains("app-button--custom-modifier", component.ClassList);
    }

    [Fact]
    public async void RendersWithDisabled()
    {
        var response = await Navigate("/Button/LinkDisabled");
        var component = response.QuerySelector(".govuk-button");

        Assert.Contains("govuk-button--disabled", component.ClassList);
    }
}
