using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Radios;

public class ErrorMessageTests : ClientBase<Startup>
{
    public ErrorMessageTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheErrorMessage()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithErrorMessage));
        var html = HtmlWithClassName(response, "govuk-error-message");

        const string expected = "<p id=\"example-error-message-error\" class=\"govuk-error-message \">Please select an option</p>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void UsesTheIdPrefixForTheErrorMessageIdIfProvided()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithErrorMessageAndIdPrefix));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("id-prefix-error", component!.Id);
    }

    [Fact]
    public async void FallsBackToUsingTheNameForTheErrorMessageId()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithErrorMessage));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("example-error-message-error", component!.Id);
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheErrorMessage()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithFieldsetAndErrorMessage));
        var fieldset = response.QuerySelector(".govuk-fieldset");
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{component!.Id}\\b"), fieldset!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheErrorMessageAndParentFieldset()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithFieldsetErrorMessageAndDescribedBy));
        var fieldset = response.QuerySelector(".govuk-fieldset");
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{component!.Id}\\b"), fieldset!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fieldset.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void RendersWithAFormGroupWrapperThatHasAnErrorState()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithErrorMessage));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("govuk-form-group--error", component!.ClassList);
    }
}
