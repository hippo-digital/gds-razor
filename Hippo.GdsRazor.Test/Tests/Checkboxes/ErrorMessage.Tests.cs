using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Controllers;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Checkboxes;

public class ErrorMessageTests : ClientBase<Startup>
{
    public ErrorMessageTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheErrorMessage()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithErrorMessage));
        var component = response.QuerySelector(".govuk-error-message");

        const string expected = "<p id=\"waste-error\" class=\"govuk-error-message \">\n  \nPlease select an option\n</p>";

        Assert.Equal(expected, component!.OuterHtml);
    }

    [Fact]
    public async void UsesTheIdPrefixForTheErrorMessageIdIfProvided()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithErrorAndIdPrefix));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("id-prefix-error", component!.Id);
    }

    [Fact]
    public async void FallsBackToUsingTheNameForTheErrorMessageId()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithErrorMessage));
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Equal("waste-error", component!.Id);
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheErrorMessage()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithFieldsetAndErrorMessage));
        var fieldset = response.QuerySelector(".govuk-fieldset");
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{component!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheErrorMessageAndParentFieldset()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithErrorMessageAndFieldsetDescribedBy));
        var fieldset = response.QuerySelector(".govuk-fieldset");
        var component = response.QuerySelector(".govuk-error-message");

        Assert.Matches(new Regex($"\\b{component!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fieldset.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void DoesNotAssociateEachInputAsDescribedByTheErrorMessage()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithErrorMessageAndHintsOnItems));
        foreach (var (item, idx) in response.QuerySelectorAll("input").Select((v, i) => (v, i)))
        {
            var expectedDescribedById = (idx == 0) ? "waste-item-hint" : $"waste-{idx + 1}-item-hint";
            Assert.Equal(expectedDescribedById, item.Attributes[AriaDescribedBy]?.Value);
        }
    }

    [Fact]
    public async void RendersWithAFormGroupWrapperThatHasAnErrorState()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithErrorMessage));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("govuk-form-group--error", component!.ClassList);
    }
}
