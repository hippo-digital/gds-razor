using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Textarea;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.Classes));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.Contains("app-textarea--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithValue()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithDefaultValue));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.Equal("221B Baker Street\nLondon\nNW1 6XE", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.Attributes));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.Equal("my data value", component!.GetAttribute("data-attribute"));
    }

    [Fact]
    public async void RendersWithAriaDescribedBy()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithDescribedBy));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.Equal("some-id", component!.GetAttribute(AriaDescribedBy));
    }

    [Fact]
    public async void RendersWithRows()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithCustomRows));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.IsAssignableFrom<IHtmlTextAreaElement>(component);
        Assert.Equal(8, ((IHtmlTextAreaElement) component!).Rows);
    }

    [Fact]
    public async void RendersWithFormGroupWrapperThatHasExtraClasses()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithOptionalFormGroupClasses));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("extra-class", component!.ClassList);
    }

    [Fact]
    public async void RendersTheAutocompleteAttribute()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithAutocompleteAttribute));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.Equal("street-address", component!.GetAttribute("autocomplete"));
    }
}
