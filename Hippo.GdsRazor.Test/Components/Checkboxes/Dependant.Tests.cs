using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Checkboxes;

public class DependantTests : ClientBase<Startup>
{
    public DependantTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HaveCorrectNestingOrder()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.FieldsetParams));
        var component = response.QuerySelectorAll(".govuk-form-group > .govuk-fieldset > .govuk-checkboxes");

        Assert.NotEmpty(component);
    }

    [Fact]
    public async void PassesThroughLabelParamsWithoutBreaking()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.LabelWithAttributes));
        var label = response.QuerySelector(".govuk-checkboxes__label");

        const string expected = "<label class=\"govuk-label govuk-checkboxes__label \" for=\"example-name\" data-attribute=\"value\" " +
                                "data-second-attribute=\"second-value\">\n      \n<b>Option 1</b>\n    </label>";

        Assert.Equal(expected, label!.OuterHtml);
    }

    [Fact]
    public async void PassesThroughFieldsetParamsWithoutBreaking()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.FieldsetParams));
        var html = HtmlWithClassName(response, "govuk-fieldset");

        const string expected = "<fieldset class=\"govuk-fieldset app-fieldset--custom-modifier\" aria-describedby=\" example-name-error\" data-attribute=\"value\" " +
                                "data-second-attribute=\"second-value\"><legend class=\"govuk-fieldset__legend \">What is your nationality?</legend></fieldset>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void PassesThroughHtmlFieldsetParamsWithoutBreaking()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.FieldsetHtmlParams));
        var html = HtmlWithClassName(response, "govuk-fieldset");

        const string expected = "<fieldset class=\"govuk-fieldset \"><legend class=\"govuk-fieldset__legend \">What is your <b>nationality</b>?</legend></fieldset>";

        Assert.Equal(expected, html);
    }
}
