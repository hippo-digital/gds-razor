using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Checkboxes;

public class HintErrorTests : ClientBase<Startup>
{
    public HintErrorTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByBothTheHintAndTheErrorMessage()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithErrorMessageAndHint));
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var fieldset = response.QuerySelector(".govuk-fieldset");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fieldset.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHintErrorMessageAndParentFieldset()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithErrorHintAndFieldsetDescribedBy));
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var fieldset = response.QuerySelector(".govuk-fieldset");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fieldset.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fieldset.GetAttribute(AriaDescribedBy) ?? "");
    }
}
