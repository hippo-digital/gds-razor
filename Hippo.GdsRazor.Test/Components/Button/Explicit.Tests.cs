using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Button;

public class ExplicitTests : ClientBase<Startup>
{
    public ExplicitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithInput()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.Input));
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlInputElement>(component);
        Assert.Equal("submit", ((IHtmlInputElement) component!).Type);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.InputAttributes));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("example-id", component!.GetAttribute("aria-controls"));
        Assert.Equal("123", component.GetAttribute("data-tracking-dimension"));
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.InputClasses));
        var component = response.QuerySelector(".govuk-button");

        Assert.Contains("app-button--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithDisabled()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.InputDisabled));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("true", component!.GetAttribute("aria-disabled"));
        Assert.True(((IHtmlInputElement) component).IsDisabled);
        Assert.Contains("govuk-button--disabled", component.ClassList);
    }

    [Fact]
    public async void RendersWithName()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.Input));
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("start-now", ((IHtmlInputElement) component!).Name);
    }

    [Fact]
    public async void RendersWithType()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.InputType));
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlInputElement>(component);
        Assert.Equal("button", ((IHtmlInputElement) component!).Type);
    }
}
