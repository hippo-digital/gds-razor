using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Textarea;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Textarea");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersWithId()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.Default));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.Equal("more-detail", component!.Id);
    }

    [Fact]
    public async void RendersWithName()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.Default));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.IsAssignableFrom<IHtmlTextAreaElement>(component);
        Assert.Equal("more-detail", ((IHtmlTextAreaElement) component!).Name);
    }

    [Fact]
    public async void RendersWithDefaultNumberOfRows()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.Default));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.IsAssignableFrom<IHtmlTextAreaElement>(component);
        Assert.Equal(5, ((IHtmlTextAreaElement) component!).Rows);
    }

    [Fact]
    public async void RendersWithAFormGroupWrapper()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.Default));
        var components = response.QuerySelectorAll(".govuk-form-group");

        Assert.NotEmpty(components);
    }
}
