using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Select;

public class HintErrorTests : ClientBase<Startup>
{
    public HintErrorTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void AssociatesTheSelectAsDescribedByBothTheHintAndTheErrorMessage()
    {
        var response = await Navigate("Select" ,nameof(SelectController.WithHintTextAndErrorMessage));
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var select = response.QuerySelector(".govuk-select");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), select!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), select.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AssociatesTheSelectAsDescribedByTheHintErrorMessageAndParentFieldset()
    {
        var response = await Navigate("Select" ,nameof(SelectController.WithHintErrorAndDescribedBy));
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var select = response.QuerySelector(".govuk-select");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), select!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), select.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), select.GetAttribute(AriaDescribedBy) ?? "");
    }
}
