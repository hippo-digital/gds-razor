using AngleSharp.Html.Dom;
using GdsRazorTest.Tests.Internal;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GdsRazorTest.Tests.BackLink;

public class ComponentTests : GdsTestBase
{
    public ComponentTests(WebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersTheDefaultExampleWithAnAnchorHrefAndTextCorrectly()
    {
        var response = await Navigate("/BackLink/Default");
        var component = response.QuerySelector(".govuk-back-link");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
        Assert.Equal("#", component.Attributes["href"].Value);
        Assert.Equal("Back", component.TextContent.Trim());
    }

    [Fact]
    public async void RendersClassesCorrectly()
    {
        var response = await Navigate("/BackLink/Classes");
        var component = response.QuerySelector(".govuk-back-link");

        Assert.Contains("app-back-link--custom-class", component.ClassList);
    }

    [Fact]
    public async void RendersCustomTextCorrectly()
    {
        var response = await Navigate("/BackLink/CustomText");
        var component = response.QuerySelector(".govuk-back-link");

        Assert.Equal("Back to home", component.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersEscapedHtmlWhenPassedToText()
    {
        var response = await Navigate("/BackLink/HtmlAsText");
        var component = response.QuerySelector(".govuk-back-link");

        Assert.Equal("&lt;b&gt;Home&lt;/b&gt;", component.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersHtmlCorrectly()
    {
        var response = await Navigate("/BackLink/Html");
        var component = response.QuerySelector(".govuk-back-link");

        Assert.Equal("<b>Back</b>", component.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersAttributesCorrectly()
    {
        var response = await Navigate("/BackLink/Attributes");
        var component = response.QuerySelector(".govuk-back-link");

        Assert.Equal("attribute", component.Attributes["data-test"].Value);
        Assert.Equal("Back to home", component.Attributes["aria-label"].Value);
    }
}
