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
                                "data-second-attribute=\"second-value\">\n    <legend class=\"govuk-fieldset__legend \">\n\nWhat is your nationality?    </legend>\n  \n\n\n\n\n\n\n</fieldset>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void PassesThroughHtmlFieldsetParamsWithoutBreaking()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.FieldsetHtmlParams));
        var fieldset = response.QuerySelector(".govuk-fieldset");
        foreach (var element in fieldset!.QuerySelectorAll("[class]:not([class^=govuk-fieldset])")) element.Remove();

        const string expected = "<fieldset class=\"govuk-fieldset \">\n    <legend class=\"govuk-fieldset__legend \">\n\nWhat is your <b>nationality</b>?    </legend>\n  \n\n\n\n\n</fieldset>";

        Assert.Equal(expected, fieldset.OuterHtml);
    }
}
