using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.FileUpload;

public class HintErrorTests : ClientBase<Startup>
{
    public HintErrorTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void AssociatesTheInputAsDescribedByBothTheHintAndTheErrorMessage()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.WithErrorMessageAndHint));
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var fileUpload = response.QuerySelector(".govuk-file-upload");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fileUpload!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fileUpload.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void AssociatesTheInputAsDescribedByTheHintErrorMessageAndParentFieldset()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.WithErrorDescribedByAndHint));
        var hint = response.QuerySelector(".govuk-hint");
        var errorMessage = response.QuerySelector(".govuk-error-message");
        var fileUpload = response.QuerySelector(".govuk-file-upload");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fileUpload!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fileUpload.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fileUpload.Attributes[AriaDescribedBy]?.Value ?? "");
    }
}
