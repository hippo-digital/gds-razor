using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Fieldset;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Fieldset");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void CreatesAFieldset()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.Default));
        var component = response.QuerySelector("fieldset.govuk-fieldset");

        Assert.IsAssignableFrom<IHtmlFieldSetElement>(component);
    }

    [Fact]
    public async void IncludesALegendElementWhichCaptionsTheFieldset()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.Default));
        var component = response.QuerySelector(".govuk-fieldset__legend");

        Assert.IsAssignableFrom<IHtmlLegendElement>(component);
    }

    [Fact]
    public async void NestsTheLegendWithinTheFieldset()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.Default));
        var components = response.QuerySelectorAll("fieldset.govuk-fieldset > .govuk-fieldset__legend");

        Assert.NotEmpty(components);
    }

    [Fact]
    public async void AllowsYouToSetTheLegendText()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.Default));
        var component = response.QuerySelector(".govuk-fieldset__legend");

        Assert.Equal("What is your address?", component!.TextContent.Trim());
    }

    [Fact]
    public async void AllowsYouToSetTheAriaDescribedByAttribute()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.WithDescribedBy));
        var component = response.QuerySelector(".govuk-fieldset");

        Assert.Equal("some-id", component!.GetAttribute(AriaDescribedBy));
    }

    [Fact]
    public async void EscapesHtmlInTheTextArgument()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.HtmlAsText));
        var component = response.QuerySelector(".govuk-fieldset__legend");

        Assert.Equal("What is &lt;b&gt;your&lt;/b&gt; address?", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void DoesNotEscapeHtmlInTheHtmlArgument()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.Html));
        var component = response.QuerySelector(".govuk-fieldset__legend");

        Assert.Equal("What is <b>your</b> address?", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void NestsTheLegendInAnH1IfTheLegendIsAPageHeading()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.AsPageHeadingL));
        var component = response.QuerySelector(".govuk-fieldset__legend > h1");

        Assert.Equal("What is your address?", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersHtmlWhenPassedAsFieldsetContent()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.HtmlFieldsetContent));
        var component = response.QuerySelector(".govuk-fieldset .my-content");

        Assert.Equal("This is some content to put inside the fieldset", component!.TextContent.Trim());
    }

    [Fact]
    public async void CanHaveAdditionalClassesOnTheLegend()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.LegendClasses));
        var component = response.QuerySelector(".govuk-fieldset__legend");

        Assert.Contains("my-custom-class", component!.ClassList);
    }

    [Fact]
    public async void CanHaveAdditionalClassesOnTheFieldset()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.Classes));
        var component = response.QuerySelector(".govuk-fieldset");

        Assert.Contains("app-fieldset--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void CanHaveAnExplicitRole()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.Role));
        var component = response.QuerySelector(".govuk-fieldset");

        Assert.Equal("group", component!.GetAttribute("role"));
    }

    [Fact]
    public async void CanHaveAdditionalAttributes()
    {
        var response = await Navigate("Fieldset" ,nameof(FieldsetController.Attributes));
        var component = response.QuerySelector(".govuk-fieldset");

        Assert.Equal("value", component!.GetAttribute("data-attribute"));
    }
}
