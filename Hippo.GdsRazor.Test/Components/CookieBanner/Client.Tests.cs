using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CookieBanner;

public class ClientTests : ClientBase<Startup>
{
    public ClientTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void Renders3Banners()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.ClientSideImplementation));
        var actions = response.QuerySelectorAll(".govuk-cookie-banner__message");

        Assert.Equal(3, actions.Length);
    }

    [Fact]
    public async void TwoBannersAreHidden()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.ClientSideImplementation));
        var actions = response.QuerySelectorAll(".govuk-cookie-banner__message[hidden]");

        Assert.Equal(2, actions.Length);
    }

    [Fact]
    public async void HasADataNoSnippetAttributeToHideItFromSearchResultSnippets()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.ClientSideImplementation));
        var parentContainer = response.QuerySelector(".govuk-cookie-banner");

        Assert.Equal("", parentContainer!.GetAttribute("data-nosnippet"));
    }
}
