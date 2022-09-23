using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Radios;

public class DependantTests : ClientBase<Startup>
{
    public DependantTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HaveCorrectNestingOrder()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.Inline));
        var component = response.QuerySelectorAll(".govuk-form-group > .govuk-fieldset > .govuk-radios");

        Assert.NotEmpty(component);
    }

    [Fact]
    public async void PassesThroughLabelParamsWithoutBreaking()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.LabelWithAttributes));
        var label = response.QuerySelector(".govuk-radios__label");

        const string expected = "<label class=\"govuk-label govuk-radios__label \" for=\"with-label-attributes\" data-attribute=\"value\" " +
                                "data-second-attribute=\"second-value\">\n      \nYes\n    </label>";

        Assert.Equal(expected, label!.OuterHtml);
    }

    [Fact]
    public async void PassesThroughFieldsetParamsWithoutBreaking()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.FieldsetParams));
        var html = HtmlWithClassName(response, "govuk-fieldset");

        const string expected = "<fieldset class=\"govuk-fieldset app-fieldset--custom-modifier\" aria-describedby=\" example-fieldset-params-hint\" data-attribute=\"value\" " +
                                "data-second-attribute=\"second-value\"><legend class=\"govuk-fieldset__legend \">Have you changed your name?</legend></fieldset>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void PassesThroughHtmlFieldsetParamsWithoutBreaking()
    {
        var response = await Navigate("Radios" ,nameof(RadiosController.FieldsetWithHtml));
        var html = HtmlWithClassName(response, "govuk-fieldset");

        const string expected = "<fieldset class=\"govuk-fieldset \"><legend class=\"govuk-fieldset__legend \">What is your <b>nationality</b>?</legend></fieldset>";

        Assert.Equal(expected, html);
    }
}
