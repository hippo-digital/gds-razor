using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Header;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Header");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void HasRoleOfBanner()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.Default));
        var component = response.QuerySelector(".govuk-header");

        Assert.Equal("banner", component!.Attributes["role"]?.Value);
    }
}
