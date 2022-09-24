using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Select;

public class HintTests : ClientBase<Startup>
{
    public HintTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheHint()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Hint));
        var html = HtmlWithClassName(response, "govuk-hint");

        const string expected = "<div id=\"select-with-hint-hint\" class=\"govuk-hint \">Hint text goes here</div>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHint()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Hint));
        var select = response.QuerySelector(".govuk-select");
        var hint = response.QuerySelector(".govuk-hint");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), select!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AssociatesTheFieldsetAsDescribedByTheHintAndParentFieldset()
    {
        var response = await Navigate("Select" ,nameof(SelectController.HintAndDescribedBy));
        var select = response.QuerySelector(".govuk-select");
        var hint = response.QuerySelector(".govuk-hint");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), select!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), select.GetAttribute(AriaDescribedBy) ?? "");
    }
}
