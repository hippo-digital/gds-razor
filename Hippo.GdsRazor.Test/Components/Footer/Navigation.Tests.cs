using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Footer;

public class NavigationTests : ClientBase<Startup>
{
    public NavigationTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Footer", "AxeNavigation");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void NoItemsDisplayedWhenNoItemArrayIsProvided()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithEmptyNavigation));
        var components = response.QuerySelectorAll(".govuk-footer__navigation");

        Assert.Empty(components);
    }

    [Fact]
    public async void RendersHeadings()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithNavigation));
        var firstHeading = response.QuerySelector(".govuk-footer__section:first-child h2.govuk-footer__heading");
        var lastHeading = response.QuerySelector(".govuk-footer__section:last-child h2.govuk-footer__heading");

        Assert.Equal("Two column list", firstHeading!.TextContent.Trim());
        Assert.Equal("Single column list", lastHeading!.TextContent.Trim());
    }

    [Fact]
    public async void RendersListsOfLinks()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithNavigation));
        var components = response.QuerySelectorAll("ul.govuk-footer__list li.govuk-footer__list-item");
        var firstItem = components.First().QuerySelector("a.govuk-footer__link:first-child");

        Assert.Equal(9, components.Length);
        Assert.IsAssignableFrom<IHtmlAnchorElement>(firstItem);
        Assert.Equal("#1", firstItem!.GetAttribute("href"));
        Assert.Equal("Navigation item 1", firstItem.TextContent.Trim());
    }

    [Fact]
    public async void RendersAttributesOnLinks()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithNavigationItemAttributes));
        var component = response.QuerySelector(".govuk-footer__list .govuk-footer__link");

        Assert.Equal("my-attribute", component!.GetAttribute("data-attribute"));
        Assert.Equal("my-attribute-2", component.GetAttribute("data-attribute-2"));
    }

    [Fact]
    public async void RendersListsInColumns()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithNavigation));
        var component = response.QuerySelector("ul.govuk-footer__list");

        Assert.Contains("govuk-footer__list--columns-2", component!.ClassList);
    }

    [Fact]
    public async void RendersOneColumnSectionFullWidthByDefault()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithDefaultWidthNavigationOneColumn));
        var component = response.QuerySelector(".govuk-footer__section");

        Assert.Contains("govuk-grid-column-full", component!.ClassList);
    }

    [Fact]
    public async void RendersTwoColumnSectionFullWidthByDefault()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithDefaultWidthNavigationTwoColumns));
        var component = response.QuerySelector(".govuk-footer__section");

        Assert.Contains("govuk-grid-column-full", component!.ClassList);
    }

    [Fact]
    public async void RendersSectionCustomWidthWhenWidthSpecified()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithNavigation));
        var component = response.QuerySelector(".govuk-footer__section");

        Assert.Contains("govuk-grid-column-two-thirds", component!.ClassList);
    }
}
