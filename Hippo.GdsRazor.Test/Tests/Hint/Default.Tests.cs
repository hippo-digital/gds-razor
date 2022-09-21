using Hippo.GdsRazor.Test.Controllers;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Hint;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Hint");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersWithText()
    {
        var response = await Navigate("Hint" ,nameof(HintController.Default));
        var component = response.QuerySelector(".govuk-hint");

        Assert.Equal("It's on your National Insurance card, benefit letter, payslip or P60. For example, 'QQ 12 34 56 C'.", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("Hint" ,nameof(HintController.Classes));
        var component = response.QuerySelector(".govuk-hint");

        Assert.Contains("app-hint--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithId()
    {
        var response = await Navigate("Hint" ,nameof(HintController.Id));
        var component = response.QuerySelector(".govuk-hint");

        Assert.Equal("my-hint", component!.Id);
    }

    [Fact]
    public async void AllowsTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("Hint" ,nameof(HintController.HtmlAsText));
        var component = response.QuerySelector(".govuk-hint");

        Assert.Equal("Unexpected &lt;strong&gt;bold text&lt;/strong&gt; in body", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsHtmlToBePassedUnescaped()
    {
        var response = await Navigate("Hint" ,nameof(HintController.Html));
        var component = response.QuerySelector(".govuk-hint");

        Assert.Equal("It's on your National Insurance card, benefit letter, payslip or <a class=\"govuk-link\" href=\"#\">P60</a>. For example, 'QQ 12 34 56 C'.", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("Hint" ,nameof(HintController.Attributes));
        var component = response.QuerySelector(".govuk-hint");

        Assert.Equal("my data value", component!.Attributes["data-attribute"]?.Value);
    }
}
