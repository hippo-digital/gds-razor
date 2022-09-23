using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.FileUpload;

public class ErrorMessageTests : ClientBase<Startup>
{
    public ErrorMessageTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithErrorMessage()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Error));
        var html = HtmlWithClassName(response, "govuk-error-message");

        const string expected = "<p id=\"file-upload-with-error-error\" class=\"govuk-error-message \">Error message</p>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void AssociatesTheInputAsDescribedByTheErrorMessage()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Error));
        var fileUpload = response.QuerySelector(".govuk-file-upload");
        var errorMessage = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fileUpload!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AssociatesTheInputAsDescribedByTheErrorMessageAndParentFieldset()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.WithErrorAndDescribedBy));
        var fileUpload = response.QuerySelector(".govuk-file-upload");
        var errorMessage = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fileUpload!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fileUpload.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void IncludesTheErrorClassOnTheComponent()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Error));
        var component = response.QuerySelector(".govuk-file-upload");

        Assert.Contains("govuk-file-upload--error", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAFormGroupWrapperThatHasAnErrorState()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Error));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("govuk-form-group--error", component!.ClassList);
    }
}
