using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Tabs;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Tabs");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersTheFirstTabSelected()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.Default));
        var component = response.QuerySelector("[href=\"#past-day\"]")!.ParentElement;

        Assert.Contains("govuk-tabs__list-item--selected", component!.ClassList);
    }

    [Fact]
    public async void HidesAllButTheFirstPanel()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.Default));
        var weekTab = response.QuerySelector("#past-week");
        var monthTab = response.QuerySelector("#past-month");
        var yearTab = response.QuerySelector("#past-year");

        Assert.Contains("govuk-tabs__panel--hidden", weekTab!.ClassList);
        Assert.Contains("govuk-tabs__panel--hidden", monthTab!.ClassList);
        Assert.Contains("govuk-tabs__panel--hidden", yearTab!.ClassList);
    }
}
