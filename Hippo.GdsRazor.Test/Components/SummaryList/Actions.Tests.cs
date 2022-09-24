using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.SummaryList;

public class ActionsTests : ClientBase<Startup>
{
    public ActionsTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public async void RendersHref()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.ActionsHref));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__actions > a");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
        Assert.Equal("https://www.gov.uk", component!.GetAttribute("href"));
    }

    [Fact]
    public async void RendersText()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.WithActions));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__actions > a");
        foreach (var componentChild in component!.Children) componentChild.Remove();

        Assert.Equal("Change", component.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersHtml()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.ActionsWithHtml));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__actions > a");

        Assert.Equal("Edit<span class=\"visually-hidden\"> name</span>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsTheVisuallyHiddenPrefixToBeRemovedAndThenManuallyAddedWithHtml()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.Translated));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__actions > a");

        Assert.Equal("Golygu<span class=\"govuk-visually-hidden\"> dyddiad geni</span>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersCustomAccessibleName()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.WithActions));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__actions > a .govuk-visually-hidden");

        Assert.Equal("date of birth", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersClasses()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.ActionsWithClasses));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__actions");

        Assert.Contains("app-custom-class", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.ActionsWithAttributes));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__actions > a");

        Assert.Equal("value", component!.GetAttribute("data-test-attribute"));
        Assert.Equal("value-2", component.GetAttribute("data-test-attribute-2"));
    }

    [Fact]
    public async void RendersASingleAnchorWithOneAction()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.SingleActionWithAnchor));
        var components = response.QuerySelectorAll(".govuk-summary-list .govuk-summary-list__actions > a");

        Assert.Equal(1, components.Length);
        Assert.Equal("First action", components.First().InnerHtml.Trim());
    }

    [Fact]
    public async void RendersAListWithMultipleActions()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.WithSomeActions));
        var components = response.QuerySelectorAll(".govuk-summary-list .govuk-summary-list__actions .govuk-summary-list__actions-list-item > a");
        var lastAction = components.Last();
        foreach (var componentChild in lastAction.Children) componentChild.Remove();

        Assert.Equal(2, components.Length);
        Assert.Equal("Delete", lastAction.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersClassesOnActions()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.ClassesOnItems));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__actions > a");

        Assert.Contains("govuk-link--no-visited-state", component!.ClassList);
    }

    [Fact]
    public async void SkipsTheActionColumnWhenNoArrayIsProvided()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.Default));
        var components = response.QuerySelectorAll(".govuk-summary-list .govuk-summary-list__actions");

        Assert.Empty(components);
    }

    [Fact]
    public async void SkipsTheActionColumnWhenNoItemsAreInTheArrayProvided()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.EmptyItemsArray));
        var components = response.QuerySelectorAll(".govuk-summary-list .govuk-summary-list__actions");

        Assert.Empty(components);
    }

    [Fact]
    public void PassesAccessibilityTestsWithSomeActions()
    {
        var axeResult = AxeResults("SummaryList", "AxeSomeActions");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void DoesNotAddNoActionsModifierClassToRowsWithActions()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.WithSomeActions));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__row:first-child");

        Assert.DoesNotContain("govuk-summary-list__row--no-actions", component!.ClassList);
    }

    [Fact]
    public async void AddsNoActionsModifierClassToRowsWithActions()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.WithSomeActions));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__row:nth-child(2)");

        Assert.Contains("govuk-summary-list__row--no-actions", component!.ClassList);
    }

    [Fact]
    public async void DoesNotAddNoActionsModifierClassToAnyOfTheRows()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.Default));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__row");

        Assert.DoesNotContain("govuk-summary-list__row--no-actions", component!.ClassList);
    }
}
