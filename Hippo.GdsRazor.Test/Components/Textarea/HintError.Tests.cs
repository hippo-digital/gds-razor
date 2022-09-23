using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Textarea;

public class HintErrorTests : ClientBase<Startup>
{
    public HintErrorTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByBothTheHintAndTheErrorMessage()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithHintAndErrorMessage));
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var textarea = response.QuerySelector(".govuk-textarea");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), textarea!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), textarea.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHintErrorMessageAndParentFieldset()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithHintErrorMessageAndDescribedBy));
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var textarea = response.QuerySelector(".govuk-textarea");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), textarea!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), textarea.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), textarea.GetAttribute(AriaDescribedBy) ?? "");
    }
}
