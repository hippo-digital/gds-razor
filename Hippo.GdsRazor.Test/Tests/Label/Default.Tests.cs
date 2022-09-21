using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Controllers;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Label;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Label");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersALabelElement()
    {
        var response = await Navigate("Label" ,nameof(LabelController.Default));
        var component = response.QuerySelector(".govuk-label");

        Assert.IsAssignableFrom<IHtmlLabelElement>(component);
    }

    [Fact]
    public async void DoesNotOutputAnythingIfNoHtmlOrTextIsProvided()
    {
        var response = await Navigate("Label" ,nameof(LabelController.Empty));
        var component = response.QuerySelectorAll(".govuk-label");

        Assert.Empty(component);
    }

    [Fact]
    public async void AllowsAdditionalClassesToBeAddedToTheComponent()
    {
        var response = await Navigate("Label" ,nameof(LabelController.Classes));
        var component = response.QuerySelector(".govuk-label");

        Assert.Contains("extra-class", component!.ClassList);
        Assert.Contains("one-more-class", component.ClassList);
    }

    [Fact]
    public async void RendersLabelText()
    {
        var response = await Navigate("Label" ,nameof(LabelController.Default));
        var component = response.QuerySelector(".govuk-label");

        Assert.Equal("National Insurance number", component!.TextContent.Trim());
    }

    [Fact]
    public async void AllowsLabelTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("Label" ,nameof(LabelController.HtmlAsText));
        var component = response.QuerySelector(".govuk-label");

        Assert.Equal("National Insurance number, &lt;em&gt;NINO&lt;/em&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsLabelHtmlToBePassedUnescaped()
    {
        var response = await Navigate("Label" ,nameof(LabelController.Html));
        var component = response.QuerySelector(".govuk-label");

        Assert.Equal("National Insurance number <em>NINO</em>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersForAttributeIfSpecified()
    {
        var response = await Navigate("Label" ,nameof(LabelController.For));
        var component = response.QuerySelector(".govuk-label");

        Assert.IsAssignableFrom<IHtmlLabelElement>(component);
        Assert.Equal("#dummy-input", ((IHtmlLabelElement) component!).HtmlFor);
    }

    [Fact]
    public async void CanBeNestedInsideAnH1UsingIsPageHeading()
    {
        var response = await Navigate("Label" ,nameof(LabelController.AsPageHeadingL));
        var component = response.QuerySelectorAll("h1 > .govuk-label");

        Assert.NotEmpty(component);
    }

    [Fact]
    public async void AllowsAdditionalAttributesToBeAddedToTheComponent()
    {
        var response = await Navigate("Label" ,nameof(LabelController.Attributes));
        var component = response.QuerySelector(".govuk-label");

        Assert.Equal("foo", component!.Attributes["first-attribute"]?.Value);
        Assert.Equal("bar", component.Attributes["second-attribute"]?.Value);
    }
}
