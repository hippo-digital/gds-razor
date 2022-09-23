using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Radios;

public class ItemsTests : ClientBase<Startup>
{
    public ItemsTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RenderAMatchingLabelAndInputUsingNameByDefault()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.Default));
        var firstInput = response.QuerySelector(".govuk-radios__item:first-child input");
        var firstLabel = response.QuerySelector(".govuk-radios__item:first-child label");

        Assert.Equal("example-default", firstInput!.Id);
        Assert.IsAssignableFrom<IHtmlLabelElement>(firstLabel);
        Assert.Equal("example-default", ((IHtmlLabelElement) firstLabel!).HtmlFor);

        var lastInput = response.QuerySelector(".govuk-radios__item:last-child input");
        var lastLabel = response.QuerySelector(".govuk-radios__item:last-child label");

        Assert.Equal("example-default-2", lastInput!.Id);
        Assert.IsAssignableFrom<IHtmlLabelElement>(lastLabel);
        Assert.Equal("example-default-2", ((IHtmlLabelElement) lastLabel!).HtmlFor);
    }

    [Fact]
    public async void RenderAMatchingLabelAndInputUsingCustomIdPrefix()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithIdPrefix));
        var firstInput = response.QuerySelector(".govuk-radios__item:first-child input");
        var firstLabel = response.QuerySelector(".govuk-radios__item:first-child label");

        Assert.Equal("example-id-prefix", firstInput!.Id);
        Assert.IsAssignableFrom<IHtmlLabelElement>(firstLabel);
        Assert.Equal("example-id-prefix", ((IHtmlLabelElement) firstLabel!).HtmlFor);

        var lastInput = response.QuerySelector(".govuk-radios__item:last-child input");
        var lastLabel = response.QuerySelector(".govuk-radios__item:last-child label");

        Assert.Equal("example-id-prefix-2", lastInput!.Id);
        Assert.IsAssignableFrom<IHtmlLabelElement>(lastLabel);
        Assert.Equal("example-id-prefix-2", ((IHtmlLabelElement) lastLabel!).HtmlFor);
    }

    [Fact]
    public async void RenderDisabled()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithDisabled));
        var lastInput = response.QuerySelector("input[value=\"verify\"]");

        Assert.IsAssignableFrom<IHtmlInputElement>(lastInput);
        Assert.True(((IHtmlInputElement) lastInput!).IsDisabled);
    }

    [Fact]
    public async void RenderChecked()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.Prechecked));
        var lastInput = response.QuerySelector(".govuk-radios .govuk-radios__item:last-child input");

        Assert.IsAssignableFrom<IHtmlInputElement>(lastInput);
        Assert.True(((IHtmlInputElement) lastInput!).IsChecked);
    }

    [Fact]
    public async void ChecksTheRadioThatMatchesValue()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.PrecheckedUsingValue));
        var lastInput = response.QuerySelector(".govuk-radios input[value=\"no\"]");

        Assert.IsAssignableFrom<IHtmlInputElement>(lastInput);
        Assert.True(((IHtmlInputElement) lastInput!).IsChecked);
    }

    [Fact]
    public async void AllowsItemCheckedToOverrideValue()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.ItemCheckedOverridesValue));
        var green = response.QuerySelector(".govuk-radios input[value=\"green\"]");

        Assert.IsAssignableFrom<IHtmlInputElement>(green);
        Assert.False(((IHtmlInputElement) green!).IsChecked);
    }

    [Fact]
    public async void RendersTheAttributes()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.ItemsWithAttributes));
        var firstInput = response.QuerySelector(".govuk-radios__item:first-child input");
        var lastInput = response.QuerySelector(".govuk-radios__item:last-child input");

        Assert.Equal("ABC", firstInput!.GetAttribute("data-attribute"));
        Assert.Equal("DEF", firstInput.GetAttribute("data-second-attribute"));

        Assert.Equal("GHI", lastInput!.GetAttribute("data-attribute"));
        Assert.Equal("JKL", lastInput.GetAttribute("data-second-attribute"));
    }
}
