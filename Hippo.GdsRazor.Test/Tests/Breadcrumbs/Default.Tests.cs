using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Breadcrumbs;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Breadcrumbs");

        Assert.Empty(axeResult.Violations);
    }

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
        Assert.Contains("govuk-breadcrumbs__link", anchor!.ClassList);
        Assert.Equal("/section", anchor.Attributes["href"]?.Value);
        Assert.Equal("Section", anchor.TextContent.Trim());
    }
}
