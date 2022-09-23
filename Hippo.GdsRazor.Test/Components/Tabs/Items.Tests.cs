using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Tabs;

public class ItemsTests : ClientBase<Startup>
{
    public ItemsTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void DoesntRenderAListIfItemsIsNotDefined()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.NoItemList));
        var components = response.QuerySelectorAll(".govuk-tabs .govuk-tabs__list");

        Assert.Empty(components);
    }

    [Fact]
    public async void RenderAMatchingTabAndPanelUsingItemId()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.Default));
        var firstTab = response.QuerySelector(".govuk-tabs .govuk-tabs__list-item:first-child .govuk-tabs__tab");
        var firstPanel = response.QuerySelector(".govuk-tabs .govuk-tabs__panel");

        Assert.Equal("#past-day", firstTab!.GetAttribute("href"));
        Assert.Equal("past-day", firstPanel!.Id);
    }

    [Fact]
    public async void RenderAMatchingTabAndPanelUsingCustomIdPrefix()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.IdPrefix));
        var firstTab = response.QuerySelector(".govuk-tabs .govuk-tabs__list-item:first-child .govuk-tabs__tab");
        var firstPanel = response.QuerySelector(".govuk-tabs .govuk-tabs__panel");

        Assert.Equal("#custom-1", firstTab!.GetAttribute("href"));
        Assert.Equal("custom-1", firstPanel!.Id);
    }

    [Fact]
    public async void RenderTheLabel()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.Default));
        var firstTab = response.QuerySelector(".govuk-tabs .govuk-tabs__list-item:first-child .govuk-tabs__tab");

        Assert.Equal("Past day", firstTab!.TextContent.Trim());
    }

    [Fact]
    public async void RenderWithPanelContentAsTextWrappedInStyledParagraph()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.Default));
        var lastTab = response.QuerySelectorAll(".govuk-tabs .govuk-tabs__panel").Last();
        var p = lastTab.QuerySelector("p");

        Assert.Contains("govuk-body", p!.ClassList);
        Assert.Equal("There is no data for this year yet, check back later", lastTab!.TextContent.Trim());
    }

    [Fact]
    public async void RenderEscapedHtmlWhenPassedToTextContent()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.HtmlAsText));
        var firstPanel = response.QuerySelector(".govuk-tabs__panel .govuk-body");

        Assert.Equal("&lt;p&gt;Panel 1 content&lt;/p&gt;", firstPanel!.InnerHtml.Trim());
    }

    [Fact]
    public async void RenderHtmlWhenPassedToContent()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.Html));
        var firstPanel = response.QuerySelector(".govuk-tabs__panel");

        Assert.Equal("<p>Panel 1 content</p>", firstPanel!.InnerHtml.Trim());
    }

    [Fact]
    public async void RenderATabAnchorWithAttributes()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.ItemWithAttributes));
        var tabItemLink = response.QuerySelector(".govuk-tabs__tab");

        Assert.Equal("my-attribute", tabItemLink!.GetAttribute("data-attribute"));
        Assert.Equal("my-attribute-2", tabItemLink.GetAttribute("data-attribute-2"));
    }

    [Fact]
    public async void RenderATabPanelWithAttributes()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.PanelWithAttributes));
        var tabItemLink = response.QuerySelector(".govuk-tabs__panel");

        Assert.Equal("my-attribute", tabItemLink!.GetAttribute("data-attribute"));
        Assert.Equal("my-attribute-2", tabItemLink.GetAttribute("data-attribute-2"));
    }
}
