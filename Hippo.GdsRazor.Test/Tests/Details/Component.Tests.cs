using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Details;

public class ComponentTests : ClientBase<Startup>
{
    public ComponentTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Details");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersADetailsElement()
    {
        var response = await Navigate("/Details/Default");
        var component = response.QuerySelector(".govuk-details");

        Assert.IsAssignableFrom<IHtmlDetailsElement>(component);
    }

    [Fact]
    public async void RendersWithACustomId()
    {
        var response = await Navigate("/Details/Id");
        var component = response.QuerySelector(".govuk-details");

        Assert.Equal("my-details-element", component!.Id);
    }

    [Fact]
    public async void IsCollapsedByDefault()
    {
        var response = await Navigate("/Details/Default");
        var component = response.QuerySelector(".govuk-details");

        Assert.NotEqual(true, component!.Attributes["open"]?.IsSpecified);
    }

    [Fact]
    public async void CanBeOpenedByDefault()
    {
        var response = await Navigate("/Details/Expanded");
        var component = response.QuerySelector(".govuk-details");

        Assert.True(component!.Attributes["open"]?.IsSpecified);
    }

    [Fact]
    public async void IncludesANestedSummary()
    {
        var response = await Navigate("/Details/Default");
        var component = response.QuerySelector(".govuk-details .govuk-details__summary");

        Assert.Equal("SUMMARY", component!.TagName);
    }

    [Fact]
    public async void AllowsTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("/Details/HtmlAsText");
        var detailsText = response.QuerySelector(".govuk-details__text");

        Assert.Equal("More about the greater than symbol (&gt;)", detailsText!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsHtmlToBePassedUnescaped()
    {
        var response = await Navigate("/Details/Html");
        var detailsText = response.QuerySelector(".govuk-details__text");

        Assert.Equal("More about <b>bold text</b>", detailsText!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsSummaryTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("/Details/SummaryHtmlAsText");
        var detailsText = response.QuerySelector(".govuk-details__summary-text");

        Assert.Equal("The greater than symbol (&gt;) is the best", detailsText!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsSummaryHtmlToBePassedUnescaped()
    {
        var response = await Navigate("/Details/SummaryHtml");
        var detailsText = response.QuerySelector(".govuk-details__summary-text");

        Assert.Equal("Use <b>bold text</b> sparingly", detailsText!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsAdditionalClassesToBeAddedToTheDetailsElement()
    {
        var response = await Navigate("/Details/Classes");
        var component = response.QuerySelector(".govuk-details");

        Assert.Contains("some-additional-class", component!.ClassList);
    }

    [Fact]
    public async void AllowsAdditionalAttributesToBeAddedToTheDetailsElement()
    {
        var response = await Navigate("/Details/Attributes");
        var component = response.QuerySelector(".govuk-details");

        Assert.Equal("i-love-data", component!.Attributes["data-some-data-attribute"]?.Value);
        Assert.Equal("foo", component!.Attributes["another-attribute"]?.Value);
    }
}
