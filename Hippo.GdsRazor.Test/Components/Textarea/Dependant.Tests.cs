using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Textarea;

public class DependantTests : ClientBase<Startup>
{
    public DependantTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HaveCorrectNestingOrder()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.Default));
        var component = response.QuerySelectorAll(".govuk-form-group > .govuk-textarea");

        Assert.NotEmpty(component);
    }

    [Fact]
    public async void RendersWithLabel()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.Default));
        var label = HtmlWithClassName(response, "govuk-label");

        const string expected = "<label class=\"govuk-label \" for=\"more-detail\">Can you provide more detail?</label>";

        Assert.Equal(expected, label);
    }

    [Fact]
    public async void RendersLabelWithForAttributeReferringTheTextareaId()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.Default));
        var component = response.QuerySelector(".govuk-label");

        Assert.IsAssignableFrom<IHtmlLabelElement>(component);
        Assert.Equal("more-detail", ((IHtmlLabelElement) component!).HtmlFor);
    }

    [Fact]
    public async void RendersLabelAsPageHeading()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithLabelAsPageHeading));
        var headings = response.QuerySelectorAll(".govuk-label-wrapper");
        var component = response.QuerySelector(".govuk-label");

        Assert.NotEmpty(headings);
        Assert.IsAssignableFrom<IHtmlLabelElement>(component);
        Assert.Equal("textarea-with-page-heading", ((IHtmlLabelElement) component!).HtmlFor);
    }
}
