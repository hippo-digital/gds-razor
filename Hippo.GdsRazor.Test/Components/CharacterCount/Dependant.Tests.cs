using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CharacterCount;

public class DependantTests : ClientBase<Startup>
{
    public DependantTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HaveCorrectNestingOrder()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.WithDefaultValueExceedingLimit));
        var component = response.QuerySelectorAll(".govuk-form-group > .govuk-js-character-count");

        Assert.NotEmpty(component);
    }

    [Fact]
    public async void RendersWithLabel()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.Default));
        var label = response.QuerySelector(".govuk-label");

        const string expected = "<label class=\"govuk-label \" for=\"more-detail\">\n      \nCan you provide more detail?\n    </label>";

        Assert.Equal(expected, label!.OuterHtml);
    }

    [Fact]
    public async void RendersLabelWithForAttributeReferencingTheCharacterCountId()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.Default));
        var component = response.QuerySelector(".govuk-label");

        Assert.IsAssignableFrom<IHtmlLabelElement>(component);
        Assert.Equal("more-detail", ((IHtmlLabelElement) component!).HtmlFor);
    }
}
