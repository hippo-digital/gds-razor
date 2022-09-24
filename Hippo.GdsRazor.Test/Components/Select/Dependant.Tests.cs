using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Select;

public class DependantTests : ClientBase<Startup>
{
    public DependantTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HaveCorrectNestingOrder()
    {
        var response = await Navigate("Select" ,nameof(SelectController.WithHintTextAndErrorMessage));
        var component = response.QuerySelectorAll(".govuk-form-group > .govuk-select");

        Assert.NotEmpty(component);
    }

    [Fact]
    public async void RendersWithLabel()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Default));
        var label = HtmlWithClassName(response, "govuk-label");

        const string expected = "<label class=\"govuk-label \" for=\"select-1\">Label text goes here</label>";

        Assert.Equal(expected, label);
    }

    [Fact]
    public async void RendersLabelWithForAttributeReferencingTheSelectId()
    {
        var response = await Navigate("Select" ,nameof(SelectController.Default));
        var component = response.QuerySelector(".govuk-label");

        Assert.IsAssignableFrom<IHtmlLabelElement>(component);
        Assert.Equal("select-1", ((IHtmlLabelElement) component!).HtmlFor);
    }
}
