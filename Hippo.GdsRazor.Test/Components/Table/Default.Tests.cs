using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Table;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Table");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void CanHadAdditionalClasses()
    {
        var response = await Navigate("Table" ,nameof(TableController.Classes));
        var component = response.QuerySelector(".govuk-table");

        Assert.Contains("custom-class-goes-here", component!.ClassList);
    }

    [Fact]
    public async void CanHaveAdditionalAttributes()
    {
        var response = await Navigate("Table" ,nameof(TableController.Attributes));
        var component = response.QuerySelector(".govuk-table");

        Assert.Equal("bar", component!.GetAttribute("data-foo"));
    }
}
