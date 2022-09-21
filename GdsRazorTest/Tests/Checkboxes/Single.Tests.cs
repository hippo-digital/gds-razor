using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.Checkboxes;

public class SingleTests : ClientBase<Startup>
{
    public SingleTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void AddsAriaDescribedByToInputIfThereIsAnError()
    {
        var response = await Navigate("/Checkboxes/WithSingleOptionSetAriaDescribedByOnInput");
        var input = response.QuerySelector("input");

        Assert.Contains("t-and-c-error", input!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void AddsAriaDescribedByToInputIfThereIsAnErrorAndParentFieldset()
    {
        var response = await Navigate("/Checkboxes/WithSingleOptionSetAriaDescribedByOnInputAndDescribedBy");
        var input = response.QuerySelector("input");

        Assert.Contains("some-id t-and-c-error", input!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void AddsAriaDescribedByToInputIfThereIsAnErrorAndAHint()
    {
        var response = await Navigate("/Checkboxes/WithSingleOptionAndHintSetAriaDescribedByOnInput");
        var input = response.QuerySelector("input");

        Assert.Contains("t-and-c-with-hint-error t-and-c-with-hint-item-hint", input!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void AddsAriaDescribedByToInputIfThereIsAnErrorHintAndParentFieldset()
    {
        var response = await Navigate("/Checkboxes/WithSingleOptionAndHintSetAriaDescribedByOnInputAndDescribedBy");
        var input = response.QuerySelector("input");

        Assert.Contains("some-id t-and-c-with-hint-error t-and-c-with-hint-item-hint", input!.Attributes[AriaDescribedBy]?.Value ?? "");
    }
}
