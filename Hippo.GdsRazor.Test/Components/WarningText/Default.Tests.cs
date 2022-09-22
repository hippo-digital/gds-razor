using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.WarningText;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("WarningText");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersWithText()
    {
        var response = await Navigate("WarningText" ,nameof(WarningTextController.Default));
        var component = response.QuerySelector(".govuk-warning-text");

        Assert.EndsWith("You can be fined up to £5,000 if you don’t register.", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithAssistiveText()
    {
        var response = await Navigate("WarningText" ,nameof(WarningTextController.Default));
        var component = response.QuerySelector(".govuk-warning-text__assistive");

        Assert.Equal("Warning", component!.TextContent.Trim());
    }

    [Fact]
    public async void HidesTheIconFromScreenReadersUsingTheAriaHiddenAttribute()
    {
        var response = await Navigate("WarningText" ,nameof(WarningTextController.Default));
        var component = response.QuerySelector(".govuk-warning-text__icon");

        Assert.Equal("true", component!.Attributes["aria-hidden"]?.Value);
    }
}
