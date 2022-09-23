using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CookieBanner;

public class ConfirmationTests : ClientBase<Startup>
{
    public ConfirmationTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("CookieBanner", "AxeConfirmation");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RoleAlertNotSetByDefault()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Default));
        var banner = response.QuerySelector(".govuk-cookie-banner .govuk-cookie-banner__message");

        Assert.Null(banner!.GetAttribute("role"));
    }

    [Fact]
    public async void SetsRoleAttributeWhenRoleProvided()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.AcceptedConfirmationBanner));
        var banner = response.QuerySelector(".govuk-cookie-banner .govuk-cookie-banner__message");

        Assert.Equal("alert", banner!.GetAttribute("role"));
    }

    [Fact]
    public async void HidesBannerIfHiddenOptionSetToTrue()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Hidden));
        var component = response.QuerySelector(".govuk-cookie-banner__message");

        Assert.NotNull(component!.GetAttribute("hidden"));
    }

    [Fact]
    public async void DoesNotHideBannerIfHiddenOptionSetToFalse()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.HiddenFalse));
        var component = response.QuerySelector(".govuk-cookie-banner__message");

        Assert.Null(component!.GetAttribute("hidden"));
    }
}
