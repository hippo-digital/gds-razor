using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Pagination;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersACustomNavigationLandmark()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.WithCustomNavigationLandmark));
        var component = response.QuerySelector(".govuk-pagination");

        Assert.Equal("search", component!.GetAttribute("aria-label"));
    }

    [Fact]
    public async void RendersTheCorrectNumberWithinEachPaginationItem()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.WithCustomLinkAndItemText));

        var previous = response.QuerySelector(".govuk-pagination__prev .govuk-pagination__link");
        var next = response.QuerySelector(".govuk-pagination__next .govuk-pagination__link");
        var firstNumber = response.QuerySelector(".govuk-pagination__item:first-child");
        var secondNumber = response.QuerySelector(".govuk-pagination__item:nth-child(2)");
        var thirdNumber = response.QuerySelector(".govuk-pagination__item:last-child");

        Assert.Equal("Previous page", previous!.TextContent.Trim());
        Assert.Equal("Next page", next!.TextContent.Trim());
        Assert.Equal("one", firstNumber!.TextContent.Trim());
        Assert.Equal("two", secondNumber!.TextContent.Trim());
        Assert.Equal("three", thirdNumber!.TextContent.Trim());
    }

    [Fact]
    public async void RendersCustomAccessibleLabelsForPaginationItems()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.WithCustomAccessibleLabelsOnItemLinks));

        var firstNumber = response.QuerySelector(".govuk-pagination__item:first-child .govuk-pagination__link");
        var secondNumber = response.QuerySelector(".govuk-pagination__item:nth-child(2) .govuk-pagination__link");
        var thirdNumber = response.QuerySelector(".govuk-pagination__item:last-child .govuk-pagination__link");

        Assert.Equal("1st page", firstNumber!.GetAttribute("aria-label"));
        Assert.Equal("2nd page (you are currently on this page)", secondNumber!.GetAttribute("aria-label"));
        Assert.Equal("3rd page", thirdNumber!.GetAttribute("aria-label"));
    }
}
