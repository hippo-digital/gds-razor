using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Header;

public class NavigationTests : ClientBase<Startup>
{
    public NavigationTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Header", "AxeNavigation");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersNavigation()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithNavigation));
        var components = response.QuerySelectorAll(".govuk-header ul.govuk-header__navigation-list li.govuk-header__navigation-item");
        var firstItem = components.First().QuerySelector("a.govuk-header__link:first-child");

        Assert.Equal(4, components.Length);
        Assert.IsAssignableFrom<IHtmlAnchorElement>(firstItem);
        Assert.Equal("#1", firstItem!.Attributes["href"]?.Value);
        Assert.Equal("Navigation item 1", firstItem.TextContent.Trim());
    }

    [Fact]
    public async void RendersNavigationDefaultLabelCorrectly()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithNavigation));
        var component = response.QuerySelector(".govuk-header nav");

        Assert.Equal("Menu", component!.Attributes["aria-label"]?.Value);
    }

    [Fact]
    public async void RendersNavigationLabelCorrectlyWhenCustomMenuButtonTextIsSet()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithCustomMenuButtonText));
        var component = response.QuerySelector(".govuk-header nav");

        Assert.Equal("Dewislen", component!.Attributes["aria-label"]?.Value);
    }

    [Fact]
    public async void AllowsNavigationLabelToBeCustomised()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithCustomNavigationLabel));
        var component = response.QuerySelector(".govuk-header nav");

        Assert.Equal("Custom navigation label", component!.Attributes["aria-label"]?.Value);
    }

    [Fact]
    public async void RendersNavigationLabelAndMenuButtonTextWhenTheseAreBothSet()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithCustomNavigationLabelAndCustomMenuButtonText));
        var nav = response.QuerySelector(".govuk-header nav");
        var button = response.QuerySelector(".govuk-header .govuk-header__menu-button");

        Assert.Equal("Custom navigation label", nav!.Attributes["aria-label"]?.Value);
        Assert.Equal("Custom menu button text", button!.TextContent.Trim());
    }

    [Fact]
    public async void RendersNavigationWithActiveItem()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithNavigation));
        var component = response.QuerySelector(".govuk-header__navigation-item:first-child");

        Assert.Contains("govuk-header__navigation-item--active", component!.ClassList);
    }

    [Fact]
    public async void AllowsNavigationItemTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.NavigationItemWithHtmlAsText));
        var component = response.QuerySelector(".govuk-header__navigation-item a");

        Assert.Equal("&lt;em&gt;Navigation item 1&lt;/em&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsNavigationItemHtmlToBePassedUnescaped()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.NavigationItemWithHtml));
        var component = response.QuerySelector(".govuk-header__navigation-item a");

        Assert.Equal("<em>Navigation item 1</em>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersNavigationItemWithTextWithoutALink()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.NavigationItemWithTextWithoutLink));
        var component = response.QuerySelector(".govuk-header__navigation-item");

        Assert.Equal("Navigation item 1", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersNavigationItemWithHtmlWithoutALink()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.NavigationItemWithHtmlWithoutLink));
        var component = response.QuerySelector(".govuk-header__navigation-item");

        Assert.Equal("<em>Navigation item 1</em>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersNavigationItemAnchorWithAttributes()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.NavigationItemWithAttributes));
        var component = response.QuerySelector(".govuk-header__navigation-item a");

        Assert.Equal("my-attribute", component!.Attributes["data-attribute"]?.Value);
        Assert.Equal("my-attribute-2", component.Attributes["data-attribute-2"]?.Value);
    }
}
