using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.DateInput;

public class DependantTests : ClientBase<Startup>
{
    public DependantTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HaveCorrectNestingOrder()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.CompleteQuestion));
        var component = response.QuerySelectorAll(".govuk-form-group > .govuk-fieldset > .govuk-date-input");

        Assert.NotEmpty(component);
    }

    [Fact]
    public async void PassesThroughLabelParamsWithoutBreaking()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Default));
        var html = HtmlWithClassName(response, "govuk-date-input__label");

        const string expected = "<label class=\"govuk-label govuk-date-input__label\" for=\"dob-day\">Day</label>" +
                                "<label class=\"govuk-label govuk-date-input__label\" for=\"dob-month\">Month</label>" +
                                "<label class=\"govuk-label govuk-date-input__label\" for=\"dob-year\">Year</label>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void PassesThroughFieldsetParamsWithoutBreaking()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.CompleteQuestion));
        var html = HtmlWithClassName(response, "govuk-fieldset");

        const string expected = "<fieldset class=\"govuk-fieldset \" role=\"group\" aria-describedby=\" dob-hint\">" +
                                "<legend class=\"govuk-fieldset__legend \">What is your date of birth?</legend></fieldset>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void PassesThroughHtmlFieldsetParamsWithoutBreaking()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.FieldsetHtml));
        var html = HtmlWithClassName(response, "govuk-fieldset");

        const string expected = "<fieldset class=\"govuk-fieldset \" role=\"group\">" +
                                "<legend class=\"govuk-fieldset__legend \">What is your <b>date of birth</b>?</legend></fieldset>";

        Assert.Equal(expected, html);
    }
}
