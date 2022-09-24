using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Select;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithId()
    {
        var response = await Navigate("Select" ,nameof(SelectController.WithFullWidthOverride));
        var component = response.QuerySelector(".govuk-select");

        Assert.Contains("govuk-!-width-full", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAriaDescribedBy()
    {
        var response = await Navigate("Select" ,nameof(SelectController.WithDescribedBy));
        var component = response.QuerySelector(".govuk-select");

        Assert.Equal("some-id", component!.GetAttribute(AriaDescribedBy));
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Attributes));
        var component = response.QuerySelector(".govuk-select");

        Assert.Equal("my data value", component!.GetAttribute("data-attribute"));
    }

    [Fact]
    public async void RendersWithAttributesOnItems()
    {
        var response = await Navigate("Select" ,nameof(SelectController.AttributesOnItems));
        var firstInput = response.QuerySelector("option:first-child");
        var lastInput = response.QuerySelector("option:last-child");

        Assert.Equal("ABC", firstInput!.GetAttribute("data-attribute"));
        Assert.Equal("DEF", firstInput.GetAttribute("data-second-attribute"));

        Assert.Equal("GHI", lastInput!.GetAttribute("data-attribute"));
        Assert.Equal("JKL", lastInput.GetAttribute("data-second-attribute"));
    }
}
