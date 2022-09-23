using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Panel;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void AllowsTitleTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.TitleHtmlAsText));
        var component = response.QuerySelector(".govuk-panel__title");

        Assert.Equal("Application &lt;strong&gt;not&lt;/strong&gt; complete", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersTitleAsSpecifiedHeadingLevel()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.CustomHeadingLevel));
        var component = response.QuerySelector(".govuk-panel__title");

        Assert.IsAssignableFrom<IHtmlHeadingElement>(component);
        Assert.Equal("H2", component!.TagName);
    }

    [Fact]
    public async void AllowsTitleHtmlToBePassedUnescaped()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.TitleHtml));
        var component = response.QuerySelector(".govuk-panel__title");

        Assert.Equal("Application <strong>not</strong> complete", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsBodyTextToBePassedWhilstEscapingHtmlEntities()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.BodyHtmlAsText));
        var component = response.QuerySelector(".govuk-panel__body");

        Assert.Equal("Your reference number&lt;br&gt;&lt;strong&gt;HDJ2123F&lt;/strong&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsBodyHtmlToBePassedUnescaped()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.BodyHtml));
        var component = response.QuerySelector(".govuk-panel__body");

        Assert.Equal("Your reference number<br><strong>HDJ2123F</strong>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowsAdditionalClassesToBeAddedToTheComponent()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.Classes));
        var component = response.QuerySelector(".govuk-panel");

        Assert.Contains("extra-class", component!.ClassList);
        Assert.Contains("one-more-class", component.ClassList);
    }

    [Fact]
    public async void AllowsAdditionalAttributesToBeAddedToTheComponent()
    {
        var response = await Navigate("Panel" ,nameof(PanelController.Attributes));
        var component = response.QuerySelector(".govuk-panel");

        Assert.Equal("foo", component!.Attributes["first-attribute"]?.Value);
        Assert.Equal("bar", component.Attributes["second-attribute"]?.Value);
    }
}
