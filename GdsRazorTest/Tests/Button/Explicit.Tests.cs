using AngleSharp.Html.Dom;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.Button;

public class ExplicitTests : ClientBase<Startup>
{
    public ExplicitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithInput()
    {
        var response = await Navigate("/Button/Input");
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlInputElement>(component);
        Assert.Equal("submit", ((IHtmlInputElement) component!).Type);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("/Button/InputAttributes");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("example-id", component!.Attributes["aria-controls"]?.Value);
        Assert.Equal("123", component.Attributes["data-tracking-dimension"]?.Value);
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("/Button/InputClasses");
        var component = response.QuerySelector(".govuk-button");

        Assert.Contains("app-button--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithDisabled()
    {
        var response = await Navigate("/Button/InputDisabled");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("true", component!.Attributes["aria-disabled"]?.Value);
        Assert.True(((IHtmlInputElement) component).IsDisabled);
        Assert.Contains("govuk-button--disabled", component.ClassList);
    }

    [Fact]
    public async void RendersWithName()
    {
        var response = await Navigate("/Button/Input");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("start-now", ((IHtmlInputElement) component!).Name);
    }

    [Fact]
    public async void RendersWithType()
    {
        var response = await Navigate("/Button/InputType");
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlInputElement>(component);
        Assert.Equal("button", ((IHtmlInputElement) component!).Type);
    }
}
