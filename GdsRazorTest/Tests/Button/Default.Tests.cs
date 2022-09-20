using AngleSharp.Html.Dom;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.Button;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Button");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersTheDefaultExample()
    {
        var response = await Navigate("/Button/Default");
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlButtonElement>(component);
        Assert.Equal("Save and continue", component!.TextContent.Trim());
    }
}
