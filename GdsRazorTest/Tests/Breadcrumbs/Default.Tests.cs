using AngleSharp.Html.Dom;
using GdsRazorTest.Tests.Internal;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GdsRazorTest.Tests.Breadcrumbs;

public class DefaultTests : GdsTestBase
{
    public DefaultTests(WebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithItems()
    {
        var response = await Navigate("/Breadcrumbs/Default");
        var items = response.QuerySelectorAll(".govuk-breadcrumbs__list-item");

        Assert.Equal(2, items.Length);
    }

    [Fact]
    public async void RendersITemWithAnchor()
    {
        var response = await Navigate("/Breadcrumbs/Default");
        var anchor = response.QuerySelector(".govuk-breadcrumbs__list-item a");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(anchor);
        Assert.Contains("govuk-breadcrumbs__link", anchor.ClassList);
        Assert.Equal("/section", anchor.Attributes["href"].Value);
        Assert.Equal("Section", anchor.TextContent.Trim());
    }
}
