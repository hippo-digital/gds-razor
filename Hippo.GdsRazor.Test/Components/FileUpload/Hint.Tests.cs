using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.FileUpload;

public class HintTests : ClientBase<Startup>
{
    public HintTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheHint()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.WithHintText));
        var html = HtmlWithClassName(response, "govuk-hint");

        const string expected = "<div id=\"file-upload-2-hint\" class=\"govuk-hint \">Your photo may be in your Pictures, Photos, Downloads or Desktop folder. " +
                                "Or in an app like iPhoto.</div>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void AssociatesTheInputAsDescribedByTheHint()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.WithHintText));
        var fileUpload = response.QuerySelector(".govuk-file-upload");
        var hint = response.QuerySelector(".govuk-hint");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fileUpload!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void AssociatesTheInputAsDescribedByTheHintAndParentFieldset()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.WithHintAndDescribedBy));
        var fileUpload = response.QuerySelector(".govuk-file-upload");
        var hint = response.QuerySelector(".govuk-hint");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fileUpload!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fileUpload.Attributes[AriaDescribedBy]?.Value ?? "");
    }
}
