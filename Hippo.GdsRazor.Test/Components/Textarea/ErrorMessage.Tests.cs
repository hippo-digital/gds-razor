using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Textarea;

public class ErrorMessageTests : ClientBase<Startup>
{
    public ErrorMessageTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithErrorMessage()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithErrorMessage));
        var html = HtmlWithClassName(response, "govuk-error-message");

        const string expected = "<p id=\"no-ni-reason-error\" class=\"govuk-error-message \">You must provide an explanation</p>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void AssociatesTheTextareaAsDescribedByTheErrorMessage()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithErrorMessage));
        var textarea = response.QuerySelector(".govuk-textarea");
        var errorMessage = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), textarea!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AssociatesTheTextareaAsDescribedByTheErrorMessageAndParentFieldset()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithErrorMessageAndDescribedBy));
        var textarea = response.QuerySelector(".govuk-textarea");
        var errorMessage = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), textarea!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), textarea.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AddsTheErrorClassToTheTextarea()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithErrorMessage));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.Contains("govuk-textarea--error", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAFormGroupWrapperThatHasAnErrorState()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithErrorMessage));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("govuk-form-group--error", component!.ClassList);
    }
}
