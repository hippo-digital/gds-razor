using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Radios;

public class ConditionalsTests : ClientBase<Startup>
{
    public ConditionalsTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HiddenByDefaultWhenNotChecked()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithConditionalItems));
        var component = response.QuerySelector(".govuk-radios__conditional");

        Assert.Equal("Email address", component!.TextContent.Trim());
        Assert.Contains("govuk-radios__conditional--hidden", component.ClassList);
    }

    [Fact]
    public async void VisibleWhenCheckedBecauseOfCheckedValue()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithConditionalItemsAndPreCheckedValue));
        var component = response.QuerySelectorAll(".govuk-radios__conditional").Last();

        Assert.Equal("Mobile phone number", component.TextContent.Trim());
        Assert.DoesNotContain("govuk-radios__conditional--hidden", component.ClassList);
    }

    [Fact]
    public async void VisibleByDefaultWhenChecked()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithConditionalItemChecked));
        var component = response.QuerySelector(".govuk-radios__conditional");

        Assert.Equal("Email address", component!.TextContent.Trim());
        Assert.DoesNotContain("govuk-radios__conditional--hidden", component.ClassList);
    }

    [Fact]
    public async void WithAssociationToTheInputTheyAreControlledBy()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithConditionalItems));
        var lastInput = response.QuerySelectorAll(".govuk-radios__input").First();
        var lastConditional = response.QuerySelectorAll(".govuk-radios__conditional").First();

        Assert.Equal("conditional-how-contacted", lastInput.GetAttribute("data-aria-controls"));
        Assert.Equal("conditional-how-contacted", lastConditional.Id);
    }

    [Fact]
    public async void OmitsEmptyConditionals()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithEmptyConditional));
        var components = response.QuerySelectorAll(".govuk-radios__conditional");

        Assert.Empty(components);
    }

    [Fact]
    public async void DoesNotAssociateRadiosWithEmptyConditionals()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithEmptyConditional));
        var firstInput = response.QuerySelector(".govuk-radios__input");

        Assert.Null(firstInput!.GetAttribute("data-aria-controls"));
    }
}
