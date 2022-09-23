using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CookieBanner;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("CookieBanner");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersAHeading()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Default));
        var heading = response.QuerySelector(".govuk-cookie-banner__heading");

        Assert.Equal("Cookies on this government service", heading!.TextContent.Trim());
    }

    [Fact]
    public async void RendersHeadingAsEscapedHtmlWhenPassedAsText()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.HeadingHtmlAsText));
        var heading = response.QuerySelector(".govuk-cookie-banner__heading");

        Assert.Equal("Cookies on &lt;span&gt;my service&lt;/span&gt;", heading!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersHeadingHtml()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.HeadingHtml));
        var heading = response.QuerySelector(".govuk-cookie-banner__heading");

        Assert.Equal("Cookies on <span>my service</span>", heading!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersMainContentText()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Default));
        var content = response.QuerySelector(".govuk-cookie-banner__content");

        Assert.Equal("We use analytics cookies to help understand how users use our service.", content!.TextContent.Trim());
    }

    [Fact]
    public async void RendersMainContentHtml()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Html));
        var content = response.QuerySelector(".govuk-cookie-banner__content");

        Assert.Equal("<p class=\"govuk-body\">We use cookies in <span>our service</span>.</p>", content!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersClasses()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Classes));
        var banner = response.QuerySelector(".govuk-cookie-banner__message");

        Assert.Contains("app-my-class", banner!.ClassList);
    }

    [Fact]
    public async void RendersAttributes()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Attributes));
        var banner = response.QuerySelector(".govuk-cookie-banner__message");

        Assert.Equal("my-value", banner!.GetAttribute("data-attribute"));
    }
}
