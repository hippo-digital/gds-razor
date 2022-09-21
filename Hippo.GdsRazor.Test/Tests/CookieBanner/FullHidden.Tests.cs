using Hippo.GdsRazor.Test.Controllers;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.CookieBanner;

public class FullHiddenTests : ClientBase<Startup>
{
    public FullHiddenTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HtmlFor3BannersIsPresent()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.FullBannerHidden));
        var messages = response.QuerySelectorAll(".govuk-cookie-banner__message");

        Assert.Equal(3, messages.Length);
    }

    [Fact]
    public async void ParentBannerIsHidden()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.FullBannerHidden));
        var cookieBanner = response.QuerySelectorAll(".govuk-cookie-banner[hidden]");

        Assert.Equal(1, cookieBanner.Length);
    }

    [Fact]
    public async void AddsClassesToParentContainerWhenProvided()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.FullBannerHidden));
        var cookieBanner = response.QuerySelector(".govuk-cookie-banner");

        Assert.Contains("hide-cookie-banner", cookieBanner!.ClassList);
    }

    [Fact]
    public async void AddsAttributesToParentContainerWhenProvided()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.FullBannerHidden));
        var cookieBanner = response.QuerySelector(".govuk-cookie-banner");

        Assert.Equal("true", cookieBanner!.Attributes["data-hide-cookie-banner"]?.Value);
    }
}
