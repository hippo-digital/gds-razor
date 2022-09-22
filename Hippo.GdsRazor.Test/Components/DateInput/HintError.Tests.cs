using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.DateInput;

public class HintErrorTests : ClientBase<Startup>
{
    public HintErrorTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void SetsTheGroupRoleOnTheFieldsetToForceJAWS18ToAnnounceTheHintAndErrorMessage()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithErrorsAndHint));
        var fieldset = response.QuerySelector(".govuk-fieldset");

        Assert.Equal("group", fieldset!.Attributes["role"]?.Value);
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByBothTheHintAndTheErrorMessage()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithErrorsAndHint));
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var fieldset = response.QuerySelector(".govuk-fieldset");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fieldset.Attributes[AriaDescribedBy]?.Value ?? "");
    }
}
