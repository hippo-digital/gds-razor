using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CharacterCount;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.Classes));
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.Contains("app-character-count--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithRows()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.WithCustomRows));
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.IsAssignableFrom<IHtmlTextAreaElement>(component);
        Assert.Equal(8, ((IHtmlTextAreaElement) component!).Rows);
    }

    [Fact]
    public async void RendersWithValue()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.WithDefaultValue));
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.Equal("221B Baker Street\nLondon\nNW1 6XE", component!.TextContent);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.Attributes));
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.Equal("my data value", component!.Attributes["data-attribute"]?.Value);
    }

    [Fact]
    public async void RendersWithFormGroup()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.FormGroupWithClasses));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("app-character-count--custom-modifier", component!.ClassList);
    }
}
