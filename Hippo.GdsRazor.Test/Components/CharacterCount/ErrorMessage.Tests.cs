using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CharacterCount;

public class ErrorMessageTests : ClientBase<Startup>
{
    public ErrorMessageTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithErrorMessage()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.WithDefaultValueExceedingLimit));
        var html = HtmlWithClassName(response, "govuk-error-message");

        const string expected = "<p id=\"exceeding-characters-error\" class=\"govuk-error-message \">Please do not exceed the maximum allowed limit</p>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void AssociatesTheCharacterCountAsDescribedByTheErrorMessage()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.WithDefaultValueExceedingLimit));
        var textarea = response.QuerySelector(".govuk-js-character-count");
        var errorMessage = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), textarea!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AddsTheErrorClassToTheCharacterCount()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.WithDefaultValueExceedingLimit));
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.Contains("govuk-textarea--error", component!.ClassList);
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.CustomClassesWithErrorMessage));
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.Contains("app-character-count--custom-modifier", component!.ClassList);
    }
}
