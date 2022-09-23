using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Button;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.Attributes));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("example-id", component!.GetAttribute("aria-controls"));
        Assert.Equal("123", component.GetAttribute("data-tracking-dimension"));
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.Classes));
        var component = response.QuerySelector(".govuk-button");

        Assert.Contains("app-button--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithDisabled()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.Disabled));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("true", component!.GetAttribute("aria-disabled"));
        Assert.Equal("disabled", component.GetAttribute("disabled"));
        Assert.Contains("govuk-button--disabled", component.ClassList);
    }

    [Fact]
    public async void RendersWithName()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.Name));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("start-now", component!.GetAttribute("name"));
    }

    [Fact]
    public async void RendersWithValue()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.Value));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("start", component!.GetAttribute("value"));
    }

    [Fact]
    public async void RendersWithType()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.Type));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("button", component!.GetAttribute("type"));
    }

    [Fact]
    public async void RendersWithHtml()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.Html));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("Start <em>now</em>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersWithPreventDoubleClickAttribute()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.PreventDoubleClick));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("true", component!.GetAttribute("data-prevent-double-click"));
    }
}
