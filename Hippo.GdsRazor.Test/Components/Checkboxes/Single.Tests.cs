using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Checkboxes;

public class SingleTests : ClientBase<Startup>
{
    public SingleTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void AddsAriaDescribedByToInputIfThereIsAnError()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithSingleOptionSetAriaDescribedByOnInput));
        var input = response.QuerySelector("input");

        Assert.Contains("t-and-c-error", input!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AddsAriaDescribedByToInputIfThereIsAnErrorAndParentFieldset()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithSingleOptionSetAriaDescribedByOnInputAndDescribedBy));
        var input = response.QuerySelector("input");

        Assert.Contains("some-id t-and-c-error", input!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AddsAriaDescribedByToInputIfThereIsAnErrorAndAHint()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithSingleOptionAndHintSetAriaDescribedByOnInput));
        var input = response.QuerySelector("input");

        Assert.Contains("t-and-c-with-hint-error t-and-c-with-hint-item-hint", input!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void AddsAriaDescribedByToInputIfThereIsAnErrorHintAndParentFieldset()
    {
        var response = await Navigate("Checkboxes" ,nameof(CheckboxesController.WithSingleOptionAndHintSetAriaDescribedByOnInputAndDescribedBy));
        var input = response.QuerySelector("input");

        Assert.Contains("some-id t-and-c-with-hint-error t-and-c-with-hint-item-hint", input!.GetAttribute(AriaDescribedBy) ?? "");
    }
}
