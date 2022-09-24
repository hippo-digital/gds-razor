using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Select;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Select");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersWithId()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Default));
        var component = response.QuerySelector(".govuk-select");

        Assert.Equal("select-1", component!.Id);
    }

    [Fact]
    public async void RendersWithName()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Default));
        var component = response.QuerySelector(".govuk-select");

        Assert.IsAssignableFrom<IHtmlSelectElement>(component);
        Assert.Equal("select-1", ((IHtmlSelectElement) component!).Name);
    }

    [Fact]
    public async void RendersWithItems()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Default));
        var components = response.QuerySelectorAll(".govuk-select option");

        Assert.Equal(3, components.Length);
    }

    [Fact]
    public async void RendersItemWithValue()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Default));
        var component = response.QuerySelector(".govuk-select option:first-child");

        Assert.IsAssignableFrom<IHtmlOptionElement>(component);
        Assert.Equal("1", ((IHtmlOptionElement) component!).Value);
    }

    [Fact]
    public async void RendersItemWithText()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Default));
        var component = response.QuerySelector(".govuk-select option:first-child");

        Assert.Equal("GOV.UK frontend option 1", component!.TextContent);
    }

    [Fact]
    public async void RendersItemWithSelected()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Default));
        var component = response.QuerySelector(".govuk-select option:nth-child(2)");

        Assert.NotNull(component!.GetAttribute("selected"));
    }

    [Fact]
    public async void SelectsOptionsUsingSelectedValue()
    {
        var response = await Navigate("Select" ,nameof(SelectController.WithSelectedValue));
        var component = response.QuerySelector("option[value=\"2\"]");

        Assert.NotNull(component!.GetAttribute("selected"));
    }

    [Fact]
    public async void AllowsItemSelectedToOverrideValue()
    {
        var response = await Navigate("Select" ,nameof(SelectController.ItemSelectedOverridesValue));
        var component = response.QuerySelector("option[value=\"green\"]");

        Assert.Null(component!.GetAttribute("selected"));
    }

    [Fact]
    public async void RendersItemWithDisabled()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Default));
        var component = response.QuerySelector(".govuk-select option:last-child");

        Assert.NotNull(component!.GetAttribute("disabled"));
    }

    [Fact]
    public async void RendersWithAFormGroupWrapper()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Default));
        var components = response.QuerySelectorAll(".govuk-form-group");

        Assert.NotEmpty(components);
    }

    [Fact]
    public async void RendersWithAFormGroupWrapperThatHasExtraClasses()
    {
        var response = await Navigate("Select" ,nameof(SelectController.WithOptionalFormGroupClasses));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("extra-class", component!.ClassList);
    }
}
