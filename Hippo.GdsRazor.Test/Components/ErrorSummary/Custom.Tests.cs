using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.ErrorSummary;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void AllowsTitleTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.HtmlAsTitleText));
        var component = response.QuerySelector(".govuk-error-summary__title");

        Assert.Equal("Alert, &lt;em&gt;alert&lt;/em&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsTitleHtmlToBePassedUnescaped()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.TitleHtml));
        var component = response.QuerySelector(".govuk-error-summary__title");

        Assert.Equal("Alert, <em>alert</em>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersDescriptionText()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.Description));
        var component = response.QuerySelector(".govuk-error-summary__body p");

        Assert.Equal("Lorem ipsum", component!.TextContent.Trim());
    }

    [Fact]
    public async void AllowsDescriptionTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.HtmlAsDescriptionText));
        var component = response.QuerySelector(".govuk-error-summary__body p");

        Assert.Equal("See &lt;span&gt;errors&lt;/span&gt; below", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsDescriptionHtmlToBePassedUnescaped()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.DescriptionHtml));
        var component = response.QuerySelector(".govuk-error-summary__body p");

        Assert.Equal("See <span>errors</span> below", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsAdditionalClassesToBeAddedToTheErrorSummaryComponent()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.Classes));
        var component = response.QuerySelector(".govuk-error-summary");

        Assert.Contains("extra-class", component!.ClassList);
        Assert.Contains("one-more-class", component.ClassList);
    }

    [Fact]
    public async void AllowsAdditionalAttributesToBeAddedToTheErrorSummaryComponent()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.Attributes));
        var component = response.QuerySelector(".govuk-error-summary");

        Assert.Equal("foo", component!.Attributes["first-attribute"]?.Value);
        Assert.Equal("bar", component.Attributes["second-attribute"]?.Value);
    }

    [Fact]
    public async void RendersAnchorTagWithAttributes()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.ErrorListWithAttributes));
        var component = response.QuerySelector(".govuk-error-summary__list a");

        Assert.Equal("my-attribute", component!.Attributes["data-attribute"]?.Value);
        Assert.Equal("my-attribute-2", component.Attributes["data-attribute-2"]?.Value);
    }

    [Fact]
    public async void RendersErrorItemText()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.WithoutLinks));
        var component = response.QuerySelector(".govuk-error-summary .govuk-error-summary__list li:first-child");

        Assert.Equal("Invalid username or password", component!.TextContent.Trim());
    }

    [Fact]
    public async void AllowsErrorItemHtmlToBePassedUnescaped()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.ErrorListWithHtml));
        var component = response.QuerySelector(".govuk-error-summary .govuk-error-summary__list li");

        Assert.Equal("The date your passport was issued <b>must</b> be in the past", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsErrorItemTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.ErrorListWithHtmlAsText));
        var component = response.QuerySelector(".govuk-error-summary .govuk-error-summary__list li");

        Assert.Equal("Descriptive link to the &lt;b&gt;question&lt;/b&gt; with an error", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsErrorItemHtmlInsideATagToBePassedUnescaped()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.ErrorListWithHtmlLink));
        var component = response.QuerySelector(".govuk-error-summary .govuk-error-summary__list li a");

        Assert.Equal("Descriptive link to the <b>question</b> with an error", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsErrorItemHtmlInsideATagToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.ErrorListWithHtmlAsTextLink));
        var component = response.QuerySelector(".govuk-error-summary .govuk-error-summary__list li a");

        Assert.Equal("Descriptive link to the &lt;b&gt;question&lt;/b&gt; with an error", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsDisablingAutoFocus()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.AutoFocusDisabled));
        var component = response.QuerySelector(".govuk-error-summary");

        Assert.Equal("true", component!.Attributes["data-disable-auto-focus"]?.Value);
    }

    [Fact]
    public async void AllowsExplicitlyEnablingAutoFocus()
    {
        var response = await Navigate("ErrorSummary" ,nameof(ErrorSummaryController.AutoFocusExplicitlyEnabled));
        var component = response.QuerySelector(".govuk-error-summary");

        Assert.Equal("false", component!.Attributes["data-disable-auto-focus"]?.Value);
    }
}
