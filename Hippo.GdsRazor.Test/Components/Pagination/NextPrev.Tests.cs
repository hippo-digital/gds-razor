using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Pagination;

public class NextPrevTests : ClientBase<Startup>
{
    public NextPrevTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void AppliesTheCorrectRelAttributeToEachLinkSoThatTheyCommunicateToSearchEnginesTheIntentOfTheLinks()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.Default));
        var previous = response.QuerySelector(".govuk-pagination__prev .govuk-pagination__link");
        var next = response.QuerySelector(".govuk-pagination__next .govuk-pagination__link");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(previous);
        Assert.Equal("prev", ((IHtmlAnchorElement) previous!).Relation);
        Assert.IsAssignableFrom<IHtmlAnchorElement>(next);
        Assert.Equal("next", ((IHtmlAnchorElement) next!).Relation);
    }

    [Fact]
    public async void SetsAriaHiddenTrueToEachLinkSoThatTheyAreIgnoredByAssistiveTechnology()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.Default));

        var previous = response.QuerySelector(".govuk-pagination__icon--prev");
        var next = response.QuerySelector(".govuk-pagination__icon--next");

        Assert.Equal("true", previous!.GetAttribute("aria-hidden"));
        Assert.Equal("true", next!.GetAttribute("aria-hidden"));

    }

    [Fact]
    public async void SetsFocusableFalseSoThatIeDoesNotTreatItAsAnInteractiveElement()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.Default));

        var previous = response.QuerySelector(".govuk-pagination__icon--prev");
        var next = response.QuerySelector(".govuk-pagination__icon--next");

        Assert.Equal("false", previous!.GetAttribute("focusable"));
        Assert.Equal("false", next!.GetAttribute("focusable"));
    }

    [Fact]
    public async void ChangesTheDisplayToPrevNextOnlyIfNoItemsAreProvided()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.WithPreviousAndNextOnly));

        var blockNav = response.QuerySelectorAll(".govuk-pagination--block");
        var previous = response.QuerySelectorAll(".govuk-pagination__prev");
        var next = response.QuerySelectorAll(".govuk-pagination__next");

        Assert.NotEmpty(blockNav);
        Assert.NotEmpty(previous);
        Assert.NotEmpty(next);
    }

    [Fact]
    public async void AppliesLabelsWhenProvided()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.WithPreviousAndNextOnlyAndLabels));

        var previous = response.QuerySelector(".govuk-pagination__prev .govuk-pagination__link-label");
        var next = response.QuerySelector(".govuk-pagination__next .govuk-pagination__link-label");

        Assert.Equal("1 of 3", previous!.TextContent.Trim());
        Assert.Equal("3 of 3", next!.TextContent.Trim());
    }

    [Fact]
    public async void AddsTheDecorationClassToTheLinkTitleIfNoLabelIsPresent()
    {
        var response = await Navigate("Pagination" ,nameof(PaginationController.WithPreviousAndNextOnly));

        var previous = response.QuerySelectorAll(".govuk-pagination__prev .govuk-pagination__link-title--decorated");
        var next = response.QuerySelectorAll(".govuk-pagination__next .govuk-pagination__link-title--decorated");

        Assert.NotEmpty(previous);
        Assert.NotEmpty(next);
    }
}
