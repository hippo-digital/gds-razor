using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CookieBanner;

public class AttributeTests : ClientBase<Startup>
{
    public AttributeTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HasARoleOfRegion()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Default));
        var component = response.QuerySelector(".govuk-cookie-banner");

        Assert.Equal("region", component!.GetAttribute("role"));
    }

    [Fact]
    public async void HasADefaultAriaLabel()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Default));
        var component = response.QuerySelector(".govuk-cookie-banner");

        Assert.Equal("Cookie banner", component!.GetAttribute("aria-label"));
    }

    [Fact]
    public async void RendersACustomAriaLabel()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.CustomAriaLabel));
        var component = response.QuerySelector(".govuk-cookie-banner");

        Assert.Equal("Cookies on GOV.UK", component!.GetAttribute("aria-label"));
    }
}
