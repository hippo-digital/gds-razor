using System.Text.RegularExpressions;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.CharacterCount;

public class HintTests : ClientBase<Startup>
{
    public HintTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithHint()
    {
        var response = await Navigate("/CharacterCount/WithHint");
        var component = response.QuerySelectorAll(".govuk-hint");

        const string expected1 = "<div id=\"with-hint-hint\" class=\"govuk-hint \">\n  \nDon't include personal or financial information, eg your National Insurance number or credit card details.\n</div>";
        const string expected2 = "<div id=\"with-hint-info\" class=\"govuk-hint govuk-character-count__message \">\n  \nYou can enter up to 10 characters\n</div>";

        Assert.Equal(expected1, component.First().OuterHtml);
        Assert.Equal(expected2, component.Last().OuterHtml);
    }

    [Fact]
    public async void AssociatesTheCharacterCountAsDescribedByTheHint()
    {
        var response = await Navigate("/CharacterCount/WithHint");
        var textarea = response.QuerySelector(".govuk-js-character-count");
        var hint = response.QuerySelector(".govuk-hint");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), textarea!.Attributes[AriaDescribedBy]?.Value ?? "");
    }
}
