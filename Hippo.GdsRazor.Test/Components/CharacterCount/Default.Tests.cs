using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CharacterCount;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("CharacterCount");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersWithId()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.Default));
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.Equal("more-detail", component!.Id);
    }

    [Fact]
    public async void RendersWithName()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.Default));
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.IsAssignableFrom<IHtmlTextAreaElement>(component);
        Assert.Equal("more-detail", ((IHtmlTextAreaElement) component!).Name);
    }

    [Fact]
    public async void RendersWithDefaultNumberOfRows()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.Default));
        var component = response.QuerySelector(".govuk-js-character-count");

        Assert.IsAssignableFrom<IHtmlTextAreaElement>(component);
        Assert.Equal(5, ((IHtmlTextAreaElement) component!).Rows);
    }
}
