using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Panel;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Panel");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersTitleText()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.Default));
        var component = response.QuerySelector(".govuk-panel__title");

        Assert.Equal("Application complete", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersTitleAsH1AsTheDefaultHeadingLevel()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.Default));
        var component = response.QuerySelector(".govuk-panel__title");

        Assert.IsAssignableFrom<IHtmlHeadingElement>(component);
        Assert.Equal("H1", component!.TagName);
    }

    [Fact]
    public async void RendersBodyText()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.Default));
        var component = response.QuerySelector(".govuk-panel__body");

        Assert.Equal("Your reference number: HDJ2123F", component!.TextContent.Trim());
    }

    [Fact]
    public async void DoesntRenderPanelBodyIfNoBodyTextIsPassed()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.TitleWithNoBodyText));
        var components = response.QuerySelectorAll(".govuk-panel__body");

        Assert.Empty(components);
    }
}
