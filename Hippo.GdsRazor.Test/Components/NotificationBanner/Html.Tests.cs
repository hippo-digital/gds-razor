using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.NotificationBanner;

public class HtmlTests : ClientBase<Startup>
{
    public HtmlTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTitleAsEscapedHtmlWhenPassedAsText()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.TitleHtmlAsText));
        var title = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal("&lt;span&gt;Important information&lt;/span&gt;", title!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersTitleAsHtml()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.TitleAsHtml));
        var title = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal("<span>Important information</span>", title!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersContentAsEscapedHtmlWhenPassedAsText()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.HtmlAsText));
        var component = response.QuerySelector(".govuk-notification-banner__content");

        const string expected = "<p class=\"govuk-notification-banner__heading\">&lt;span&gt;This publication was withdrawn on 7 March 2014.&lt;/span&gt;</p>";

        Assert.Equal(expected, component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersContentAsHtml()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.WithTextAsHtml));
        var component = response.QuerySelector(".govuk-notification-banner__content");

        const string expected =
            "<h3 class=\"govuk-notification-banner__heading\">This publication was withdrawn on 7 March 2014</h3>\n  <p class=\"govuk-body\">Archived and replaced by the " +
            "<a href=\"#\" class=\"govuk-notification-banner__link\">new planning guidance</a> launched 6 March 2014 on an external website</p>";

        Assert.Equal(expected, component!.InnerHtml.Trim());
    }
}
