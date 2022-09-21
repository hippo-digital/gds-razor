using Hippo.GdsRazor.Test.Controllers;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.ErrorMessage;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("ErrorMessage");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersWithACustomId()
    {
        var response = await Navigate("ErrorMessage" ,nameof(ErrorMessageController.Id));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("my-error-message-id", component!.Id);
    }

    [Fact]
    public async void AllowsAdditionalClassesToBeSpecified()
    {
        var response = await Navigate("ErrorMessage" ,nameof(ErrorMessageController.Classes));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Contains("custom-class", component!.ClassList);
    }

    [Fact]
    public async void AllowsTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("ErrorMessage" ,nameof(ErrorMessageController.HtmlAsText));
        var component = response.QuerySelector(".govuk-error-message");
        component!.QuerySelector(".govuk-visually-hidden")!.Remove();

        Assert.Equal("Unexpected &gt; in body", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsSummaryHtmlToBePassedUnescaped()
    {
        var response = await Navigate("ErrorMessage" ,nameof(ErrorMessageController.Html));
        var component = response.QuerySelector(".govuk-error-message");
        component!.QuerySelector(".govuk-visually-hidden")!.Remove();

        Assert.Equal("Unexpected <b>bold text</b> in body copy", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsAdditionalAttributesToBeSpecified()
    {
        var response = await Navigate("ErrorMessage" ,nameof(ErrorMessageController.Attributes));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("attribute", component!.Attributes["data-test"]?.Value);
    }

    [Fact]
    public async void IncludesAVisuallyHiddenErrorPrefixByDefault()
    {
        var response = await Navigate("ErrorMessage" ,nameof(ErrorMessageController.Default));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("Error:\n  \nError message about full name goes here", component!.TextContent.Trim());
    }

    [Fact]
    public async void AllowsTheVisuallyHiddenPrefixToBeCustomised()
    {
        var response = await Navigate("ErrorMessage" ,nameof(ErrorMessageController.WithVisuallyHiddenText));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("Gwall:\n  \nRhowch eich enw llawn", component!.TextContent.Trim());
    }

    [Fact]
    public async void AllowsTheVisuallyHiddenPrefixToBeRemoved()
    {
        var response = await Navigate("ErrorMessage" ,nameof(ErrorMessageController.VisuallyHiddenTextRemoved));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("There is an error on line 42", component!.TextContent.Trim());
    }

    [Fact]
    public async void AllowsTheVisuallyHiddenPrefixToBeRemovedAndThenManuallyAddedWithHtml()
    {
        var response = await Navigate("ErrorMessage" ,nameof(ErrorMessageController.Translated));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("<span class=\"govuk-visually-hidden\">Gwall:</span> Neges gwall am yr enw llawn yn mynd yma", component!.InnerHtml.Trim());
    }
}
