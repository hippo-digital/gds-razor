using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Pagination;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Pagination");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersTheCorrectUrlsForEachLink()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.Default));

        var previous = response.QuerySelector(".govuk-pagination__prev .govuk-pagination__link");
        var next = response.QuerySelector(".govuk-pagination__next .govuk-pagination__link");
        var firstNumber = response.QuerySelector(".govuk-pagination__item:first-child .govuk-pagination__link");
        var secondNumber = response.QuerySelector(".govuk-pagination__item:nth-child(2) .govuk-pagination__link");
        var thirdNumber = response.QuerySelector(".govuk-pagination__item:last-child .govuk-pagination__link");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(previous);
        Assert.Equal("/previous", previous!.GetAttribute("href"));
        Assert.IsAssignableFrom<IHtmlAnchorElement>(next);
        Assert.Equal("/next", next!.GetAttribute("href"));
        Assert.IsAssignableFrom<IHtmlAnchorElement>(firstNumber);
        Assert.Equal("/page/1", firstNumber!.GetAttribute("href"));
        Assert.IsAssignableFrom<IHtmlAnchorElement>(secondNumber);
        Assert.Equal("/page/2", secondNumber!.GetAttribute("href"));
        Assert.IsAssignableFrom<IHtmlAnchorElement>(thirdNumber);
        Assert.Equal("/page/3", thirdNumber!.GetAttribute("href"));
    }

    [Fact]
    public async void RendersTheCorrectNumberWithinEachPaginationItem()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.Default));
        var firstNumber = response.QuerySelector(".govuk-pagination__item:first-child");
        var secondNumber = response.QuerySelector(".govuk-pagination__item:nth-child(2)");
        var thirdNumber = response.QuerySelector(".govuk-pagination__item:last-child");

        Assert.Equal("1", firstNumber!.TextContent.Trim());
        Assert.Equal("2", secondNumber!.TextContent.Trim());
        Assert.Equal("3", thirdNumber!.TextContent.Trim());
    }

    [Fact]
    public async void MarksUpTheCurrentItemCorrectly()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.Default));
        var currentNumber = response.QuerySelector(".govuk-pagination__item--current .govuk-pagination__link");

        Assert.Equal("page", currentNumber!.GetAttribute("aria-current"));
    }

    [Fact]
    public async void MarksUpPaginationItemsAsEllipsesWhenSpecified()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.WithManyPages));
        var firstEllipsis = response.QuerySelector(".govuk-pagination__item:nth-child(2).govuk-pagination__item--ellipses");

        Assert.NotNull(firstEllipsis);
        Assert.Equal("\u22ef", firstEllipsis!.TextContent.Trim());
    }
}
