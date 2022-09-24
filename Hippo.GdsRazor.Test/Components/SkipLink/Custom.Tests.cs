using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.SkipLink;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersHref()
    {
        var response = await Navigate("SkipLink" ,nameof(SkipLinkController.CustomHref));
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
        Assert.Equal("#custom", component!.GetAttribute("href"));
    }

    [Fact]
    public async void RendersText()
    {
        var response = await Navigate("SkipLink" ,nameof(SkipLinkController.CustomText));
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.Equal("skip", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersEscapedHtmlInText()
    {
        var response = await Navigate("SkipLink" ,nameof(SkipLinkController.HtmlAsText));
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.Equal("&lt;p&gt;skip&lt;/p&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersHtml()
    {
        var response = await Navigate("SkipLink" ,nameof(SkipLinkController.Html));
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.Equal("<p>skip</p>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersClasses()
    {
        var response = await Navigate("SkipLink" ,nameof(SkipLinkController.Classes));
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.Contains("app-skip-link--custom-class", component!.ClassList);
    }

    [Fact]
    public async void RendersAttributes()
    {
        var response = await Navigate("SkipLink" ,nameof(SkipLinkController.Attributes));
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.Equal("attribute", component!.GetAttribute("data-test"));
        Assert.Equal("Skip to content", component.GetAttribute("aria-label"));
    }

    [Fact]
    public async void RendersADataModuleAttributeToInitialiseJavaScript()
    {
        var response = await Navigate("SkipLink" ,nameof(SkipLinkController.Default));
        var component = response.QuerySelector(".govuk-skip-link");

        Assert.Equal("govuk-skip-link", component!.GetAttribute("data-module"));
    }
}
