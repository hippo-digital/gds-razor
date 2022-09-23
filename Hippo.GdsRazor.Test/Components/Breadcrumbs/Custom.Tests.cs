using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Breadcrumbs;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersItemWithText()
    {
        var response = await Navigate("Breadcrumbs" ,nameof(BreadcrumbsController.WithLastBreadcrumbAsCurrentPage));
        var item = response.QuerySelectorAll(".govuk-breadcrumbs__list-item").Last();

        Assert.Equal("Travel abroad", item.TextContent.Trim());
    }

    [Fact]
    public async void RendersItemWithEscapedEntitiesInText()
    {
        var response = await Navigate("Breadcrumbs" ,nameof(BreadcrumbsController.HtmlAsText));
        var item = response.QuerySelector(".govuk-breadcrumbs__list-item");

        Assert.Equal("&lt;span&gt;Section 1&lt;/span&gt;", item!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersItemWithHtml()
    {
        var response = await Navigate("Breadcrumbs" ,nameof(BreadcrumbsController.Html));
        var item = response.QuerySelector(".govuk-breadcrumbs__list-item");

        Assert.Equal("<em>Section 1</em>", item!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersItemWithHtmlInsideAnchor()
    {
        var response = await Navigate("Breadcrumbs" ,nameof(BreadcrumbsController.Html));
        var anchor = response.QuerySelectorAll(".govuk-breadcrumbs__list-item a").Last();

        Assert.Equal("<em>Section 2</em>", anchor.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersItemAnchorWithAttributes()
    {
        var response = await Navigate("Breadcrumbs" ,nameof(BreadcrumbsController.ItemAttributes));
        var breadcrumbLink = response.QuerySelector(".govuk-breadcrumbs__link");

        Assert.Equal("my-attribute", breadcrumbLink!.GetAttribute("data-attribute"));
        Assert.Equal("my-attribute-2", breadcrumbLink.GetAttribute("data-attribute-2"));
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("Breadcrumbs" ,nameof(BreadcrumbsController.Classes));
        var component = response.QuerySelector(".govuk-breadcrumbs");

        Assert.Contains("app-breadcrumbs--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("Breadcrumbs" ,nameof(BreadcrumbsController.Attributes));
        var component = response.QuerySelector(".govuk-breadcrumbs");

        Assert.Equal("my-navigation", component!.Id);
        Assert.Equal("navigation", component.GetAttribute("role"));
    }

    [Fact]
    public async void RendersItemAsCollapsedOnMobileIfSpecified()
    {
        var response = await Navigate("Breadcrumbs" ,nameof(BreadcrumbsController.WithCollapseOnMobile));
        var component = response.QuerySelector(".govuk-breadcrumbs");

        Assert.Contains("govuk-breadcrumbs--collapse-on-mobile", component!.ClassList);

    }
}
