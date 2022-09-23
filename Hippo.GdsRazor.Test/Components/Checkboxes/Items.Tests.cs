using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Checkboxes;

public class ItemsTests : ClientBase<Startup>
{
    public ItemsTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RenderAMatchingLabelAndInputUsingNameByDefault()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.Default));
        var firstInput = response.QuerySelector(".govuk-checkboxes__item:first-child input");
        var firstLabel = response.QuerySelector(".govuk-checkboxes__item:first-child label");

        Assert.Equal("nationality", firstInput!.Id);
        Assert.IsAssignableFrom<IHtmlLabelElement>(firstLabel);
        Assert.Equal("nationality", ((IHtmlLabelElement) firstLabel!).HtmlFor);

        var lastInput = response.QuerySelector(".govuk-checkboxes__item:last-child input");
        var lastLabel = response.QuerySelector(".govuk-checkboxes__item:last-child label");

        Assert.Equal("nationality-3", lastInput!.Id);
        Assert.IsAssignableFrom<IHtmlLabelElement>(lastLabel);
        Assert.Equal("nationality-3", ((IHtmlLabelElement) lastLabel!).HtmlFor);
    }

    [Fact]
    public async void RenderAMatchingLabelAndInputUsingCustomIdPrefix()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithIdPrefix));
        var firstInput = response.QuerySelector(".govuk-checkboxes__item:first-child input");
        var firstLabel = response.QuerySelector(".govuk-checkboxes__item:first-child label");

        Assert.Equal("nationality", firstInput!.Id);
        Assert.IsAssignableFrom<IHtmlLabelElement>(firstLabel);
        Assert.Equal("nationality", ((IHtmlLabelElement) firstLabel!).HtmlFor);

        var lastInput = response.QuerySelector(".govuk-checkboxes__item:last-child input");
        var lastLabel = response.QuerySelector(".govuk-checkboxes__item:last-child label");

        Assert.Equal("nationality-2", lastInput!.Id);
        Assert.IsAssignableFrom<IHtmlLabelElement>(lastLabel);
        Assert.Equal("nationality-2", ((IHtmlLabelElement) lastLabel!).HtmlFor);
    }

    [Fact]
    public async void RenderExplicitlyPassedItemIds()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithIdAndName));
        var lastInput = response.QuerySelector(".govuk-checkboxes__item:last-child input");

        Assert.Equal("with-id-and-name-3", lastInput!.Id);

        var firstInput = response.QuerySelector(".govuk-checkboxes__item:first-child input");
        var firstLabel = response.QuerySelector(".govuk-checkboxes__item:first-child label");

        Assert.Equal("item_british", firstInput!.Id);
        Assert.IsAssignableFrom<IHtmlLabelElement>(firstLabel);
        Assert.Equal("item_british", ((IHtmlLabelElement) firstLabel!).HtmlFor);
    }

    [Fact]
    public async void RenderExplicitlyPassedItemNames()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithIdAndName));
        var lastInput = response.QuerySelector(".govuk-checkboxes__item:last-child input");

        Assert.IsAssignableFrom<IHtmlInputElement>(lastInput);
        Assert.Equal("custom-name-scottish", ((IHtmlInputElement) lastInput!).Name);
    }

    [Fact]
    public async void RenderDisabled()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithDisabledItem));
        var lastInput = response.QuerySelector(".govuk-checkboxes__item:last-child input");

        Assert.IsAssignableFrom<IHtmlInputElement>(lastInput);
        Assert.True(((IHtmlInputElement) lastInput!).IsDisabled);
    }

    [Fact]
    public async void RenderChecked()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithCheckedItem));
        var secondInput = response.QuerySelector(".govuk-checkboxes__item:nth-child(2) input");
        var lastInput = response.QuerySelector(".govuk-checkboxes__item:last-child input");

        Assert.IsAssignableFrom<IHtmlInputElement>(secondInput);
        Assert.True(((IHtmlInputElement) secondInput!).IsChecked);
        Assert.IsAssignableFrom<IHtmlInputElement>(lastInput);
        Assert.True(((IHtmlInputElement) lastInput!).IsChecked);
    }

    [Fact]
    public async void ChecksTheCheckboxesInValues()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithPrecheckedValues));
        var british = response.QuerySelector(".govuk-checkboxes input[value=\"british\"]");
        var other = response.QuerySelector(".govuk-checkboxes input[value=\"other\"]");

        Assert.IsAssignableFrom<IHtmlInputElement>(british);
        Assert.True(((IHtmlInputElement) british!).IsChecked);
        Assert.IsAssignableFrom<IHtmlInputElement>(other);
        Assert.True(((IHtmlInputElement) other!).IsChecked);
    }

    [Fact]
    public async void AllowsItemCheckedToOverrideValues()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.ItemCheckedOverridesValues));
        var green = response.QuerySelector(".govuk-checkboxes input[value=\"green\"]");

        Assert.IsAssignableFrom<IHtmlInputElement>(green);
        Assert.False(((IHtmlInputElement) green!).IsChecked);
    }

    [Fact]
    public async void RendersTheAttributes()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.ItemsWithAttributes));
        var firstInput = response.QuerySelector(".govuk-checkboxes__item:first-child input");
        var lastInput = response.QuerySelector(".govuk-checkboxes__item:last-child input");

        Assert.Equal("ABC", firstInput!.GetAttribute("data-attribute"));
        Assert.Equal("DEF", firstInput.GetAttribute("data-second-attribute"));

        Assert.Equal("GHI", lastInput!.GetAttribute("data-attribute"));
        Assert.Equal("JKL", lastInput.GetAttribute("data-second-attribute"));
    }
}
