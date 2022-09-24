using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Select;

public class ErrorMessageTests : ClientBase<Startup>
{
    public ErrorMessageTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheErrorMessage()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Error));
        var html = HtmlWithClassName(response, "govuk-error-message");

        const string expected = "<p id=\"select-with-error-error\" class=\"govuk-error-message \">Error message</p>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void AssociatesTheSelectAsDescribedByTheErrorMessage()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Error));
        var select = response.QuerySelector(".govuk-select");
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{component!.Id}\\b"), select!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AssociatesTheSelectAsDescribedByTheErrorMessageAndParentFieldset()
    {
        var response = await Navigate("Select" ,nameof(SelectController.ErrorAndDescribedBy));
        var select = response.QuerySelector(".govuk-select");
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{component!.Id}\\b"), select!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), select.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AddsTheErrorClassToTheSelect()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Error));
        var component = response.QuerySelector(".govuk-select");

        Assert.Contains("govuk-select--error", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAFormGroupWrapperThatHasAnErrorState()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Error));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("govuk-form-group--error", component!.ClassList);
    }
}
