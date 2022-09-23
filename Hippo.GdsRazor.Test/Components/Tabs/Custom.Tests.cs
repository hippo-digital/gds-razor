using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Tabs;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.Classes));
        var component = response.QuerySelector(".govuk-tabs");

        Assert.Contains("app-tabs--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithId()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.Id));
        var component = response.QuerySelector(".govuk-tabs");

        Assert.Equal("my-tabs", component!.Id);
    }

    [Fact]
    public async void AllowsCustomTitleTextToBePassed()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.Title));
        var component = response.QuerySelector(".govuk-tabs__title");

        Assert.Equal("Custom title for Contents", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersAttributes()
    {
        var response = await Navigate("Tabs" ,nameof(TabsController.Attributes));
        var component = response.QuerySelector(".govuk-tabs");

        Assert.Equal("my data value", component!.GetAttribute("data-attribute"));
    }
}
