using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Controllers;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Checkboxes;

public class HintTests : ClientBase<Startup>
{
    public HintTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void ItRendersTheHintText()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithHintsOnItems));
        var component = response.QuerySelector(".govuk-checkboxes__hint");

        Assert.Equal("You'll have a user ID if you've registered for Self Assessment or filed a tax return online before.", component!.TextContent.Trim());
    }

    [Fact]
    public async void ItRendersTheCorrectIdAttributeForTheHint()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithHintsOnItems));
        var component = response.QuerySelector(".govuk-checkboxes__hint");

        Assert.Equal("government-gateway-item-hint", component!.Id);
    }

    [Fact]
    public async void TheInputDescribedByAttributeMatchesTheItemHintId()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithHintsOnItems));
        var component = response.QuerySelector(".govuk-checkboxes__input");

        Assert.Contains("government-gateway-item-hint", component!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void RendersTheHint()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.MultipleHints));
        var components = response.QuerySelectorAll(".govuk-hint");

        const string expected1 = "<div id=\"example-multiple-hints-hint\" class=\"govuk-hint \">\n  \nIf you have dual nationality, select all options that are relevant to you.\n</div>";
        const string expected2 = "<div id=\"example-multiple-hints-item-hint\" class=\"govuk-hint govuk-checkboxes__hint \">\n  \nHint for british option here\n</div>";
        const string expected3 = "<div id=\"example-multiple-hints-3-item-hint\" class=\"govuk-hint govuk-checkboxes__hint \">\n  \nHint for other option here\n</div>";

        Assert.Equal(expected1, components[0].OuterHtml);
        Assert.Equal(expected2, components[1].OuterHtml);
        Assert.Equal(expected3, components[2].OuterHtml);
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHint()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithIdAndName));
        var hint = response.QuerySelector(".govuk-hint");
        var fieldset = response.QuerySelector(".govuk-fieldset");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHintAndParentFieldset()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithFieldsetDescribedBy));
        var hint = response.QuerySelector(".govuk-hint");
        var fieldset = response.QuerySelector(".govuk-fieldset");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fieldset.Attributes[AriaDescribedBy]?.Value ?? "");
    }
}
