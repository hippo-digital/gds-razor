using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.CharacterCount;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("/CharacterCount/Classes");
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.Contains("app-character-count--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithRows()
    {
        var response = await Navigate("/CharacterCount/WithCustomRows");
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.IsAssignableFrom<IHtmlTextAreaElement>(component);
        Assert.Equal(8, ((IHtmlTextAreaElement) component!).Rows);
    }

    [Fact]
    public async void RendersWithValue()
    {
        var response = await Navigate("/CharacterCount/WithDefaultValue");
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.Equal("221B Baker Street\nLondon\nNW1 6XE", component!.TextContent);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("/CharacterCount/Attributes");
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.Equal("my data value", component!.Attributes["data-attribute"]?.Value);
    }

    [Fact]
    public async void RendersWithFormGroup()
    {
        var response = await Navigate("/CharacterCount/FormGroupWithClasses");
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("app-character-count--custom-modifier", component!.ClassList);
    }
}
