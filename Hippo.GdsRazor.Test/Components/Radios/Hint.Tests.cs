using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Radios;

public class HintTests : ClientBase<Startup>
{
    public HintTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void ItRendersTheHintText()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithHintsOnItems));
        var component = response.QuerySelector(".govuk-radios__hint");

        Assert.Equal("You'll have a user ID if you've registered for Self Assessment or filed a tax return online before.", component!.TextContent.Trim());
    }

    [Fact]
    public async void ItRendersTheCorrectIdAttributeForTheHint()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithHintsOnItems));
        var component = response.QuerySelector(".govuk-radios__hint");

        Assert.Equal("gateway-item-hint", component!.Id);
    }

    [Fact]
    public async void TheInputDescribedByAttributeMatchesTheItemHintId()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithHintsOnItems));
        var component = response.QuerySelector(".govuk-radios__input");

        Assert.Equal("gateway-item-hint", component!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void RendersTheHint()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithHintsOnParentAndItems));
        var components = response.QuerySelectorAll(".govuk-hint");

        const string expected1 = "<div id=\"example-multiple-hints-hint\" class=\"govuk-hint \">\n  \nThis includes changing your last name or spelling your name differently.\n</div>";
        const string expected2 = "<div id=\"example-multiple-hints-item-hint\" class=\"govuk-hint govuk-radios__hint \">\n  \nHint for yes option here\n</div>";
        const string expected3 = "<div id=\"example-multiple-hints-2-item-hint\" class=\"govuk-hint govuk-radios__hint \">\n  \nHint for no option here\n</div>";

        Assert.Equal(expected1, components[0].OuterHtml);
        Assert.Equal(expected2, components[1].OuterHtml);
        Assert.Equal(expected3, components[2].OuterHtml);
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHint()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithHintsOnParentAndItems));
        var hint = response.QuerySelector(".govuk-hint");
        var fieldset = response.QuerySelector(".govuk-fieldset");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHintAndParentFieldset()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithDescribedByAndHint));
        var hint = response.QuerySelector(".govuk-hint");
        var fieldset = response.QuerySelector(".govuk-fieldset");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fieldset.GetAttribute(AriaDescribedBy) ?? "");
    }
}
