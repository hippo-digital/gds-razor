using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Header;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersAttributesCorrectly()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.Attributes));
        var component = response.QuerySelector(".govuk-header");

        Assert.Equal("value", component!.Attributes["data-test-attribute"]?.Value);
        Assert.Equal("value-2", component.Attributes["data-test-attribute-2"]?.Value);
    }

    [Fact]
    public async void RendersClasses()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.Classes));
        var component = response.QuerySelector(".govuk-header");

        Assert.Contains("app-header--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersCustomContainerClasses()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.FullWidth));
        var component = response.QuerySelector(".govuk-header .govuk-header__container");

        Assert.Contains("govuk-header__container--full-width", component!.ClassList);
    }

    [Fact]
    public async void RendersCustomNavigationClasses()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.FullWidthWithNavigation));
        var component = response.QuerySelector(".govuk-header .govuk-header__navigation");

        Assert.Contains("govuk-header__navigation--end", component!.ClassList);
    }

    [Fact]
    public async void RendersHomePageUrl()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.CustomHomepageUrl));
        var component = response.QuerySelector(".govuk-header .govuk-header__link--homepage");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
        Assert.Equal("/", component!.Attributes["href"]?.Value);
    }

    [Fact]
    public async void RendersProductName()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithProductName));
        var component = response.QuerySelector(".govuk-header .govuk-header__product-name");

        Assert.Equal("Product Name", component!.TextContent.Trim());
    }
}
