using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.DateInput;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Classes));
        var component = response.QuerySelector(".govuk-date-input");

        Assert.Contains("app-date-input--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Attributes));
        var component = response.QuerySelector(".govuk-date-input");

        Assert.Equal("my data value", component!.GetAttribute("data-attribute"));
    }

    [Fact]
    public async void RendersWithInputAttributes()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithInputAttributes));
        var input1 = response.QuerySelector(".govuk-date-input__item:nth-of-type(1) input");
        var input2 = response.QuerySelector(".govuk-date-input__item:nth-of-type(2) input");
        var input3 = response.QuerySelector(".govuk-date-input__item:nth-of-type(3) input");

        Assert.Equal("day", input1!.GetAttribute("data-example-day"));
        Assert.Equal("month", input2!.GetAttribute("data-example-month"));
        Assert.Equal("year", input3!.GetAttribute("data-example-year"));
    }

    [Fact]
    public async void RendersItemsWithName()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithNestedName));
        var component = response.QuerySelector(".govuk-date-input__item:first-child input");

        Assert.IsAssignableFrom<IHtmlInputElement>(component);
        Assert.Equal("day[dd]", ((IHtmlInputElement) component!).Name);
    }

    [Fact]
    public async void RendersInputsWithCustomPatternAttribute()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.CustomPattern));
        var component = response.QuerySelector(".govuk-date-input__item:first-child input");

        Assert.Equal("[0-8]*", component!.GetAttribute("pattern"));
    }

    [Fact]
    public async void RendersInputsWithCustomInputmodeText()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.CustomInputmode));
        var component = response.QuerySelector(".govuk-date-input__item:first-child input");

        Assert.Equal("text", component!.GetAttribute("inputmode"));
    }

    [Fact]
    public async void RendersWithAFormGroupWrapperThatHasExtraClasses()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithOptionalFormGroupClasses));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("extra-class", component!.ClassList);
    }
}
