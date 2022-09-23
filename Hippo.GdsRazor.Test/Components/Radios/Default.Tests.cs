using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Radios;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Radios");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RenderExampleWithMinimumRequiredNameAndItems()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.Default));
        var firstInput = response.QuerySelector(".govuk-radios .govuk-radios__item:first-child input");
        var firstLabel = response.QuerySelector(".govuk-radios .govuk-radios__item:first-child label");

        Assert.IsAssignableFrom<IHtmlInputElement>(firstInput);
        Assert.Equal("example-default", ((IHtmlInputElement) firstInput!).Name);
        Assert.Equal("yes", ((IHtmlInputElement) firstInput).Value);
        Assert.IsAssignableFrom<IHtmlLabelElement>(firstLabel);
        Assert.Equal("Yes", ((IHtmlLabelElement) firstLabel!).TextContent.Trim());

        var lastInput = response.QuerySelector(".govuk-radios .govuk-radios__item:last-child input");
        var lastLabel = response.QuerySelector(".govuk-radios .govuk-radios__item:last-child label");

        Assert.IsAssignableFrom<IHtmlInputElement>(lastInput);
        Assert.Equal("example-default", ((IHtmlInputElement) lastInput!).Name);
        Assert.Equal("no", ((IHtmlInputElement) lastInput).Value);
        Assert.IsAssignableFrom<IHtmlLabelElement>(lastLabel);
        Assert.Equal("No", ((IHtmlLabelElement) lastLabel!).TextContent.Trim());
    }

    [Fact]
    public async void RenderClasses()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.Inline));
        var component = response.QuerySelector(".govuk-radios");

        Assert.Contains("govuk-radios--inline", component!.ClassList);
    }

    [Fact]
    public async void RendersInitialAriaDescribedByOnFieldset()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.FieldsetWithDescribedBy));
        var component = response.QuerySelector(".govuk-fieldset");

        Assert.Contains("some-id", component!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void RenderAttributes()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.Attributes));
        var component = response.QuerySelector(".govuk-radios");

        Assert.Equal("value", component!.GetAttribute("data-attribute"));
        Assert.Equal("second-value", component.GetAttribute("data-second-attribute"));
    }

    [Fact]
    public async void RenderACustomClassOnTheFormGroup()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithOptionalFormGroupClassesShowingGroupError));
        var formGroup = response.QuerySelector(".govuk-form-group");

        Assert.Contains("govuk-form-group--error", formGroup!.ClassList);
    }

    [Fact]
    public async void RenderDivider()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.WithADivider));
        var component = response.QuerySelector(".govuk-radios .govuk-radios__divider");

        Assert.Equal("or", component!.TextContent.Trim());
    }

    [Fact]
    public async void RenderAdditionalLabelClasses()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.LabelWithClasses));
        var component = response.QuerySelector(".govuk-radios .govuk-radios__item label");

        Assert.Contains("bold", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAFormGroupWrapper()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.Default));
        var components = response.QuerySelectorAll(".govuk-form-group");

        Assert.NotEmpty(components);
    }
}
