using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.DateInput;

public class ItemsTests : ClientBase<Startup>
{
    public ItemsTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersDefaultsWhenAnEmptyItemArrayIsProvided()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithEmptyItems));
        var components = response.QuerySelectorAll(".govuk-date-input__item");

        Assert.Equal(3, components.Length);
    }

    [Fact]
    public async void RendersWithDefaultItems()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.Default));
        var components = response.QuerySelectorAll(".govuk-date-input__item");
        var firstItemInput = response.QuerySelector(".govuk-date-input:first-child .govuk-date-input__input");

        Assert.Equal(3, components.Length);

        Assert.IsAssignableFrom<IHtmlInputElement>(firstItemInput);
        Assert.Equal("day", ((IHtmlInputElement) firstItemInput!).Name);
    }

    [Fact]
    public async void RendersItemWithSuffixedNameForInput()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.CompleteQuestion));
        var component = response.QuerySelector(".govuk-date-input__item:first-child input");

        Assert.IsAssignableFrom<IHtmlInputElement>(component);
        Assert.Equal("dob-day", ((IHtmlInputElement) component!).Name);
    }

    [Fact]
    public async void RendersItemsWithId()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithIdOnItems));
        var component = response.QuerySelector(".govuk-date-input__item:first-child input");

        Assert.Equal("day", component!.Id);
    }

    [Fact]
    public async void RendersItemsWithSuffixedIdForInput()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.SuffixedId));
        var component = response.QuerySelector(".govuk-date-input__item:first-child input");

        Assert.Equal("my-date-input-day", component!.Id);
    }

    [Fact]
    public async void RendersItemsWithValue()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithValues));
        var component = response.QuerySelector(".govuk-date-input__item:last-child input");

        Assert.IsAssignableFrom<IHtmlInputElement>(component);
        Assert.Equal("2018", ((IHtmlInputElement) component!).Value);
    }

    [Fact]
    public async void CanHaveClassesForIndividualItems()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.ItemsWithClasses));
        var input1 = response.QuerySelector("[name=\"day\"]");
        var input2 = response.QuerySelector("[name=\"month\"]");
        var input3 = response.QuerySelector("[name=\"year\"]");

        Assert.Contains("app-date-input__day", input1!.ClassList);
        Assert.Contains("app-date-input__month", input2!.ClassList);
        Assert.Contains("app-date-input__year", input3!.ClassList);
    }

    [Fact]
    public async void DoesNotSetClassesAsUndefinedIfNoneAreDefined()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.ItemsWithoutClasses));
        var input1 = response.QuerySelector("[name=\"day\"]");
        var input2 = response.QuerySelector("[name=\"month\"]");
        var input3 = response.QuerySelector("[name=\"year\"]");

        Assert.DoesNotContain("undefined", input1!.ClassList);
        Assert.DoesNotContain("undefined", input2!.ClassList);
        Assert.DoesNotContain("undefined", input3!.ClassList);
    }

    [Fact]
    public async void RendersTheAutocompleteAttribute()
    {
        var response = await Navigate("DateInput" ,nameof(DateInputController.WithAutocompleteValues));
        var component = response.QuerySelector(".govuk-date-input__item:first-child input");

        Assert.Equal("bday-day", component!.GetAttribute("autocomplete"));
    }
}
