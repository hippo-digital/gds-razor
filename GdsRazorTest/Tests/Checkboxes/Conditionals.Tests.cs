using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.Checkboxes;

public class ConditionalsTests : ClientBase<Startup>
{
    public ConditionalsTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HiddenByDefaultWhenNotChecked()
    {
        var response = await Navigate("/Checkboxes/WithConditionalItems");
        var component = response.QuerySelector(".govuk-checkboxes__conditional");

        Assert.Equal("Email address", component!.TextContent.Trim());
        Assert.Contains("govuk-checkboxes__conditional--hidden", component.ClassList);
    }

    [Fact]
    public async void VisibleByDefaultWhenChecked()
    {
        var response = await Navigate("/Checkboxes/WithConditionalItemChecked");
        var component = response.QuerySelector(".govuk-checkboxes__conditional");

        Assert.Equal("Email address", component!.TextContent.Trim());
        Assert.DoesNotContain("govuk-checkboxes__conditional--hidden", component.ClassList);
    }

    [Fact]
    public async void VisibleWhenCheckedWithPrecheckedValues()
    {
        var response = await Navigate("/Checkboxes/WithPrecheckedValues");
        var component = response.QuerySelector(".govuk-checkboxes__conditional");

        Assert.Equal("Country", component!.TextContent.Trim());
        Assert.DoesNotContain("govuk-checkboxes__conditional--hidden", component.ClassList);
    }

    [Fact]
    public async void WithAssociationToTheInputTheyAreControlledBy()
    {
        var response = await Navigate("/Checkboxes/WithConditionalItems");
        var lastInput = response.QuerySelectorAll(".govuk-checkboxes__input").Last();
        var lastConditional = response.QuerySelectorAll(".govuk-checkboxes__conditional").Last();

        Assert.Equal("conditional-how-contacted-3", lastInput.Attributes["data-aria-controls"]?.Value);
        Assert.Equal("conditional-how-contacted-3", lastConditional.Id);
    }

    [Fact]
    public async void OmitsEmptyConditionals()
    {
        var response = await Navigate("/Checkboxes/EmptyConditional");
        var components = response.QuerySelectorAll(".govuk-checkboxes__conditional");

        Assert.Empty(components);
    }

    [Fact]
    public async void DoesNotAssociateCheckboxesWithEmptyConditionals()
    {
        var response = await Navigate("/Checkboxes/EmptyConditional");
        var firstInput = response.QuerySelector(".govuk-checkboxes__input");

        Assert.Null(firstInput!.Attributes["data-aria-controls"]?.Value);
    }
}
