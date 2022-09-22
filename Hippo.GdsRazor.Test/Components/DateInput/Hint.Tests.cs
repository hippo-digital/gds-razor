using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.DateInput;

public class HintTests : ClientBase<Startup>
{
    public HintTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheHint()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.CompleteQuestion));
        var html = HtmlWithClassName(response, "govuk-hint");

        const string expected = "<div id=\"dob-hint\" class=\"govuk-hint \">For example, 31 3 1980</div>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHint()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.CompleteQuestion));
        var fieldset = response.QuerySelector(".govuk-fieldset");
        var hint = response.QuerySelector(".govuk-hint");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHintAndParentFieldset()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithHintAndDescribedBy));
        var fieldset = response.QuerySelector(".govuk-fieldset");
        var hint = response.QuerySelector(".govuk-hint");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), fieldset!.Attributes[AriaDescribedBy]?.Value ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), fieldset.Attributes[AriaDescribedBy]?.Value ?? "");
    }
}
