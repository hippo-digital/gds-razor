using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.BackLink;

public class ComponentTests : ClientBase<Startup>
{
    public ComponentTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("BackLink");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersTheDefaultExampleWithAnAnchorHrefAndTextCorrectly()
    {
        var response = await Navigate("BackLink" ,nameof(BackLinkController.Default));
        var component = response.QuerySelector(".govuk-back-link");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
        Assert.Equal("#", component!.Attributes["href"]?.Value);
        Assert.Equal("Back", component.TextContent.Trim());
    }

    [Fact]
    public async void RendersClassesCorrectly()
    {
        var response = await Navigate("BackLink" ,nameof(BackLinkController.Classes));
        var component = response.QuerySelector(".govuk-back-link");

        Assert.Contains("app-back-link--custom-class", component!.ClassList);
    }

    [Fact]
    public async void RendersCustomTextCorrectly()
    {
        var response = await Navigate("BackLink" ,nameof(BackLinkController.CustomText));
        var component = response.QuerySelector(".govuk-back-link");

        Assert.Equal("Back to home", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersEscapedHtmlWhenPassedToText()
    {
        var response = await Navigate("BackLink" ,nameof(BackLinkController.HtmlAsText));
        var component = response.QuerySelector(".govuk-back-link");

        Assert.Equal("&lt;b&gt;Home&lt;/b&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersHtmlCorrectly()
    {
        var response = await Navigate("BackLink" ,nameof(BackLinkController.Html));
        var component = response.QuerySelector(".govuk-back-link");

        Assert.Equal("<b>Back</b>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersAttributesCorrectly()
    {
        var response = await Navigate("BackLink" ,nameof(BackLinkController.Attributes));
        var component = response.QuerySelector(".govuk-back-link");

        Assert.Equal("attribute", component!.Attributes["data-test"]?.Value);
        Assert.Equal("Back to home", component.Attributes["aria-label"]?.Value);
    }
}
