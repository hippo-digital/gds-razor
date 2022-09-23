using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.ErrorSummary;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("ErrorSummary");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void HadAChildContainerWithTheRoleAlertAttribute()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.Default));
        var component = response.QuerySelector(".govuk-error-summary div:first-child");

        Assert.Equal("alert", component!.GetAttribute("role"));
    }

    [Fact]
    public async void RendersTitleText()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.Default));
        var component = response.QuerySelector(".govuk-error-summary__title");

        Assert.Equal("There is a problem", component!.TextContent.Trim());
    }

    [Fact]
    public async void NumberOfErrorItemsMatchesTheNumberOfItemsSpecified()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.Default));
        var components = response.QuerySelectorAll(".govuk-error-summary .govuk-error-summary__list li");

        Assert.Equal(2, components.Length);
    }

    [Fact]
    public async void ErrorListItemIsAnAnchorTagIfHrefAttributeIsSpecified()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.Default));
        var component = response.QuerySelector(".govuk-error-summary .govuk-error-summary__list li:first-child *");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
    }

    [Fact]
    public async void RenderAnchorTagHrefAttributeCorrectly()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.Default));
        var component = response.QuerySelector(".govuk-error-summary .govuk-error-summary__list li:first-child a");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
        Assert.Equal("#example-error-1", component!.GetAttribute("href"));
    }
}
