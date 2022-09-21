using System.Text.RegularExpressions;
using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.CharacterCount;

public class DependantTests : ClientBase<Startup>
{
    public DependantTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HaveCorrectNestingOrder()
    {
        var response = await Navigate("/CharacterCount/WithDefaultValueExceedingLimit");
        var component = response.QuerySelectorAll(".govuk-form-group > .govuk-js-character-count");

        Assert.NotEmpty(component);
    }

    [Fact]
    public async void RendersWithLabel()
    {
        var response = await Navigate("/CharacterCount/Default");
        var label = response.QuerySelector(".govuk-label");

        const string expected = "<label class=\"govuk-label \" for=\"more-detail\">\n    \nCan you provide more detail?\n  </label>";

        Assert.Equal(expected, label!.OuterHtml);
    }

    [Fact]
    public async void RendersLabelWithForAttributeReferringTheCharacterCountId()
    {
        var response = await Navigate("/CharacterCount/Default");
        var component = response.QuerySelector(".govuk-label");

        Assert.IsAssignableFrom<IHtmlLabelElement>(component);
        Assert.Equal("more-detail", ((IHtmlLabelElement) component!).HtmlFor);
    }
}
