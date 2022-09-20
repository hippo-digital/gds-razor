using AngleSharp.Html.Dom;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.InsetText;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("InsetText");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("/InsetText/Classes");
        var component = response.QuerySelector(".govuk-inset-text");

        Assert.Contains("app-inset-text--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithId()
    {
        var response = await Navigate("/InsetText/Id");
        var component = response.QuerySelector(".govuk-inset-text");

        Assert.Equal("my-inset-text", component!.Id);
    }

    [Fact]
    public async void AllowsTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("/InsetText/HtmlAsText");
        var component = response.QuerySelector(".govuk-inset-text");

        Assert.Equal("It can take &lt;b&gt;up to 8 weeks&lt;/b&gt; to register a lasting power of attorney if there are no mistakes in the application.", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsHtmlToBePassedUnescaped()
    {
        var response = await Navigate("/InsetText/WithHtml");
        var mainContent = response.QuerySelector(".govuk-inset-text .govuk-body:first-child");
        var warningContent = response.QuerySelector(".govuk-inset-text .govuk-warning-text__text");

        Assert.Equal("It can take up to 8 weeks to register a lasting power of attorney if there are no mistakes in the application.", mainContent!.TextContent.Trim());
        Assert.Equal("Warning\n                You can be fined up to £5,000 if you don’t register.", warningContent!.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("/InsetText/Attributes");
        var component = response.QuerySelector(".govuk-inset-text");

        Assert.Equal("my data value", component!.Attributes["data-attribute"]?.Value);
    }
}
