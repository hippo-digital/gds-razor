using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.DateInput;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("DateInput");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersWithId()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Default));
        var component = response.QuerySelector(".govuk-date-input");

        Assert.Equal("dob", component!.Id);
    }

    [Fact]
    public async void RendersDefaultInputs()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Default));
        var components = response.QuerySelectorAll(".govuk-date-input__item");

        Assert.Equal(3, components.Length);
    }

    [Fact]
    public async void RendersItemWithCapitalisedLabelText()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Default));
        var component = response.QuerySelector(".govuk-date-input__item:first-child");

        Assert.Equal("Day", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersInputWithTypeText()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Default));
        var component = response.QuerySelector(".govuk-date-input__item:first-child input");

        Assert.IsAssignableFrom<IHtmlInputElement>(component);
        Assert.Equal("text", ((IHtmlInputElement) component!).Type);
    }

    [Fact]
    public async void RendersInputWithInputmodeNumeric()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Default));
        var component = response.QuerySelector(".govuk-date-input__item:first-child input");

        Assert.Equal("numeric", component!.Attributes["inputmode"]?.Value);
    }

    [Fact]
    public async void RendersItemWithImplicitClassForLabel()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Default));
        var component = response.QuerySelector(".govuk-date-input__item:first-child label");

        Assert.Contains("govuk-date-input__label", component!.ClassList);
    }

    [Fact]
    public async void RendersItemWithImplicitClassForInput()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Default));
        var component = response.QuerySelector(".govuk-date-input__item:first-child input");

        Assert.Contains("govuk-date-input__input", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAFormGroupWrapper()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Default));
        var components = response.QuerySelectorAll(".govuk-form-group");

        Assert.NotEmpty(components);
    }
}
