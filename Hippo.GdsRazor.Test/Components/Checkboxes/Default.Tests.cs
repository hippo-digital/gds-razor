using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Checkboxes;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Checkboxes");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RenderExampleWithMinimumRequiredNameAndItems()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.Default));
        var firstInput = response.QuerySelector(".govuk-checkboxes__item:first-child input");
        var firstLabel = response.QuerySelector(".govuk-checkboxes__item:first-child label");

        Assert.IsAssignableFrom<IHtmlInputElement>(firstInput);
        Assert.Equal("nationality", ((IHtmlInputElement) firstInput!).Name);
        Assert.Equal("british", ((IHtmlInputElement) firstInput).Value);
        Assert.IsAssignableFrom<IHtmlLabelElement>(firstLabel);
        Assert.Equal("British", ((IHtmlLabelElement) firstLabel!).TextContent.Trim());

        var lastInput = response.QuerySelector(".govuk-checkboxes__item:last-child input");
        var lastLabel = response.QuerySelector(".govuk-checkboxes__item:last-child label");

        Assert.IsAssignableFrom<IHtmlInputElement>(lastInput);
        Assert.Equal("nationality", ((IHtmlInputElement) lastInput!).Name);
        Assert.Equal("other", ((IHtmlInputElement) lastInput).Value);
        Assert.IsAssignableFrom<IHtmlLabelElement>(lastLabel);
        Assert.Equal("Citizen of another country", ((IHtmlLabelElement) lastLabel!).TextContent.Trim());
    }

    [Fact]
    public async void RenderExampleWithADividerAndNoneCheckboxWithExclusiveBehaviour()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithDividerAndNone));
        var component = response.QuerySelector(".govuk-checkboxes");
        var divider = component!.QuerySelector(".govuk-checkboxes__divider");
        var items = component.QuerySelectorAll(".govuk-checkboxes__item");
        var orItemInput = items.Last().QuerySelector("input");

        Assert.Equal("or", divider!.TextContent.Trim());
        Assert.Equal(4, items.Length);
        Assert.Equal("exclusive", orItemInput!.Attributes["data-behaviour"]?.Value);
    }

    [Fact]
    public async void RenderAdditionalLabelClasses()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithLabelClasses));
        var component = response.QuerySelector(".govuk-checkboxes");
        var label = component!.QuerySelector(".govuk-checkboxes__item label");

        Assert.Contains("bold", label!.ClassList);
    }

    [Fact]
    public async void RenderClasses()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.Classes));
        var component = response.QuerySelector(".govuk-checkboxes");

        Assert.Contains("app-checkboxes--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersInitialAriaDescribedByOnFieldset()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithFieldsetDescribedBy));
        var component = response.QuerySelector(".govuk-fieldset");

        Assert.Contains("some-id", component!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void RenderAttributes()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.Attributes));
        var component = response.QuerySelector(".govuk-checkboxes");

        Assert.Equal("value", component!.Attributes["data-attribute"]?.Value);
        Assert.Equal("second-value", component.Attributes["data-second-attribute"]?.Value);
    }

    [Fact]
    public async void RendersWithAFormGroupWrapper()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.Default));
        var formGroup = response.QuerySelector(".govuk-form-group");

        Assert.NotNull(formGroup);
    }

    [Fact]
    public async void RenderACustomClassOnTheFormGroup()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithOptionalFormGroupClassesShowingGroupError));
        var formGroup = response.QuerySelector(".govuk-form-group");

        Assert.Contains("govuk-form-group--error", formGroup!.ClassList);
    }
}
