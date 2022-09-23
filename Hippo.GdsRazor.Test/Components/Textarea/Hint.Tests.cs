using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Textarea;

public class HintTests : ClientBase<Startup>
{
    public HintTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithHint()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithHint));
        var component = HtmlWithClassName(response, "govuk-hint");

        const string expected = "<div id=\"more-detail-hint\" class=\"govuk-hint \">Don't include personal or financial information, eg your National Insurance number or credit card details.</div>";

        Assert.Equal(expected, component);
    }

    [Fact]
    public async void AssociatesTheTextareaAsDescribedByTheHint()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithHint));
        var textarea = response.QuerySelector(".govuk-textarea");
        var hint = response.QuerySelector(".govuk-hint");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), textarea!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AssociatesTheTextareaAsDescribedByTheHintAndParentFieldset()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithHintAndDescribedBy));
        var textarea = response.QuerySelector(".govuk-textarea");
        var hint = response.QuerySelector(".govuk-hint");

        Assert.Matches(new Regex($"\\b{hint!.Id}\\b"), textarea!.GetAttribute(AriaDescribedBy) ?? "");
        Assert.Matches(new Regex("\\bsome-id\\b"), textarea.GetAttribute(AriaDescribedBy) ?? "");
    }
}
