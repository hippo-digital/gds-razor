using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Button;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("/Button/Attributes");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("example-id", component!.Attributes["aria-controls"]?.Value);
        Assert.Equal("123", component.Attributes["data-tracking-dimension"]?.Value);
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("/Button/Classes");
        var component = response.QuerySelector(".govuk-button");

        Assert.Contains("app-button--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithDisabled()
    {
        var response = await Navigate("/Button/Disabled");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("true", component!.Attributes["aria-disabled"]?.Value);
        Assert.Equal("disabled", component.Attributes["disabled"]?.Value);
        Assert.Contains("govuk-button--disabled", component.ClassList);
    }

    [Fact]
    public async void RendersWithName()
    {
        var response = await Navigate("/Button/Name");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("start-now", component!.Attributes["name"]?.Value);
    }

    [Fact]
    public async void RendersWithValue()
    {
        var response = await Navigate("/Button/Value");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("start", component!.Attributes["value"]?.Value);
    }

    [Fact]
    public async void RendersWithType()
    {
        var response = await Navigate("/Button/Type");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("button", component!.Attributes["type"]?.Value);
    }

    [Fact]
    public async void RendersWithHtml()
    {
        var response = await Navigate("/Button/Html");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("Start <em>now</em>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersWithPreventDoubleClickAttribute()
    {
        var response = await Navigate("/Button/PreventDoubleClick");
        var component = response.QuerySelector(".govuk-button");

        Assert.Equal("true", component!.Attributes["data-prevent-double-click"]?.Value);
    }
}
