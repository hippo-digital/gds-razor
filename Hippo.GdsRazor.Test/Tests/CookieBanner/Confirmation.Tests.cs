using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.CookieBanner;

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
        var response = await Navigate("/CookieBanner/Default");
        var banner = response.QuerySelector(".govuk-cookie-banner .govuk-cookie-banner__message");

        Assert.Null(banner!.Attributes["role"]?.Value);
    }

    [Fact]
    public async void SetsRoleAttributeWhenRoleProvided()
    {
        var response = await Navigate("/CookieBanner/AcceptedConfirmationBanner");
        var banner = response.QuerySelector(".govuk-cookie-banner .govuk-cookie-banner__message");

        Assert.Equal("alert", banner!.Attributes["role"]?.Value);
    }

    [Fact]
    public async void HidesBannerIfHiddenOptionSetToTrue()
    {
        var response = await Navigate("/CookieBanner/Hidden");
        var component = response.QuerySelector(".govuk-cookie-banner__message");

        Assert.NotNull(component!.Attributes["hidden"]?.Value);
    }

    [Fact]
    public async void DoesNotHideBAnnerIfHiddenOptionSetToFalse()
    {
        var response = await Navigate("/CookieBanner/HiddenFalse");
        var component = response.QuerySelector(".govuk-cookie-banner__message");

        Assert.Null(component!.Attributes["hidden"]?.Value);
    }
}
