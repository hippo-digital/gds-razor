using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Button;

public class LinkTests : ClientBase<Startup>
{
    public LinkTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithAnchorHrefAndAnAccessibleRoleOfButton()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.ExplicitLink));
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
        Assert.Equal("/", component!.Attributes["href"]?.Value);
        Assert.Equal("button", component.Attributes["role"]?.Value);
        Assert.Equal("Continue", component.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithHashHrefIfNoHrefPassed()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.NoHref));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("#", component!.Attributes["href"]?.Value);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.LinkAttributes));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("example-id", component!.Attributes["aria-controls"]?.Value);
        Assert.Equal("123", component.Attributes["data-tracking-dimension"]?.Value);
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.LinkClasses));
        var component = response.QuerySelector(".govuk-button");

        Assert.Contains("app-button--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithDisabled()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.LinkDisabled));
        var component = response.QuerySelector(".govuk-button");

        Assert.Contains("govuk-button--disabled", component!.ClassList);
    }
}
