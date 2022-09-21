using System.Text.RegularExpressions;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.Checkboxes;

public class HintErrorTests : ClientBase<Startup>
{
    public HintErrorTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByBothTheHintAndTheErrorMessage()
    {
        var response = await Navigate("/Checkboxes/WithErrorMessageAndHint");
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var fieldset = response.QuerySelector(".govuk-fieldset");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHintErrorMessageAndParentFieldset()
    {
        var response = await Navigate("/Checkboxes/WithErrorHintAndFieldsetDescribedBy");
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var fieldset = response.QuerySelector(".govuk-fieldset");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
    }
}
