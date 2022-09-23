using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Footer;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Footer");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void EntireComponentMustHaveRoleOfContentinfo()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.Default));
        var component = response.QuerySelector(".govuk-footer");

        Assert.Equal("contentinfo", component!.GetAttribute("role"));
    }

    [Fact]
    public async void RendersAttributesCorrectly()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.Attributes));
        var component = response.QuerySelector(".govuk-footer");

        Assert.Equal("value", component!.GetAttribute("data-test-attribute"));
        Assert.Equal("value-2", component.GetAttribute("data-test-attribute-2"));
    }

    [Fact]
    public async void RendersClasses()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.Classes));
        var component = response.QuerySelector(".govuk-footer");

        Assert.Contains("app-footer--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersCustomContainerClasses()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithContainerClasses));
        var component = response.QuerySelector(".govuk-footer .govuk-width-container");

        Assert.Contains("app-width-container", component!.ClassList);
    }
}
