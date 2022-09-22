using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.DateInput;

public class ErrorMessageTests : ClientBase<Startup>
{
    public ErrorMessageTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheErrorMessage()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithErrorsOnly));
        var html = HtmlWithClassName(response, "govuk-error-message");

        const string expected = "<p id=\"dob-errors-error\" class=\"govuk-error-message \">Error message goes here</p>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void UsesTheIdAsAPrefixForTheErrorMessageId()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithErrorsOnly));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("dob-errors-error", component!.Id);
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheErrorMessage()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithErrorsOnly));
        var fieldset = response.QuerySelector(".govuk-fieldset");
        var errorMessage = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheErrorMessageAndParentFieldset()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithErrorAndDescribedBy));
        var fieldset = response.QuerySelector(".govuk-fieldset");
        var errorMessage = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{errorMessage!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fieldset.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void RendersWithAFormGroupWrapperThatHasAnErrorState()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithErrorsOnly));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("govuk-form-group--error", component!.ClassList);
    }
}
