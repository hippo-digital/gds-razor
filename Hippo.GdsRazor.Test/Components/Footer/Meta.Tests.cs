using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Footer;

public class MetaTests : ClientBase<Startup>
{
    public MetaTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Footer", "AxeMeta");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersHeading()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithMeta));
        var component = response.QuerySelector(".govuk-footer h2.govuk-visually-hidden");

        Assert.Equal("Items", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersDefaultHeadingWhenNoneSupplied()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithEmptyMeta));
        var component = response.QuerySelector(".govuk-footer h2.govuk-visually-hidden");

        Assert.Equal("Support links", component!.TextContent.Trim());
    }

    [Fact]
    public async void DoesntRenderFooterLinkListWhenNoItemsAreProvided()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithEmptyMetaItems));
        var components = response.QuerySelectorAll(".govuk-footer__inline-list");

        Assert.Empty(components);
    }

    [Fact]
    public async void RendersLinks()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithMeta));
        var items = response.QuerySelectorAll("ul.govuk-footer__inline-list li.govuk-footer__inline-list-item");
        var firstItem = items.First().QuerySelector("a.govuk-footer__link:first-child");

        Assert.Equal(3, items.Length);
        Assert.IsAssignableFrom<IHtmlAnchorElement>(firstItem);
        Assert.Equal("#1", firstItem!.Attributes["href"]?.Value);
        Assert.Equal("Item 1", firstItem.TextContent.Trim());
    }

    [Fact]
    public async void RendersCustomMetaText()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithCustomMeta));
        var component = response.QuerySelector(".govuk-footer__meta-custom");

        Assert.Equal("GOV.UK Prototype Kit v7.0.1", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersCustomMetaHtmlAsText()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.MetaHtmlAsText));
        var component = response.QuerySelector(".govuk-footer__meta-custom");

        Assert.Equal("GOV.UK Prototype Kit &lt;strong&gt;v7.0.1&lt;/strong&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersCustomMetaHtml()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithMetaHtml));
        var component = response.QuerySelector(".govuk-footer__meta-custom");

        Assert.Equal("GOV.UK Prototype Kit <strong>v7.0.1</strong>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersAttributesOnMetaLinks()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithMetaItemAttributes));
        var component = response.QuerySelector(".govuk-footer__meta .govuk-footer__link");

        Assert.Equal("my-attribute", component!.Attributes["data-attribute"]?.Value);
        Assert.Equal("my-attribute-2", component.Attributes["data-attribute-2"]?.Value);
    }
}
