using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.NotificationBanner;

public class TypeTests : ClientBase<Startup>
{
    public TypeTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithAppropriateClass()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.WithTypeSuccess));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Contains("govuk-notification-banner--success", component!.ClassList);
    }

    [Fact]
    public async void HasRoleAlertAttribute()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.WithTypeSuccess));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Equal("alert", component!.GetAttribute("role"));
    }

    [Fact]
    public async void DoesRenderAriaLabelledBy()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.WithTypeSuccess));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Equal("govuk-notification-banner-title", component!.GetAttribute("aria-labelledby"));
    }

    [Fact]
    public async void RendersATitleIdForAriaLabelledBy()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.WithTypeSuccess));
        var component = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal("govuk-notification-banner-title", component!.Id);
    }

    [Fact]
    public async void RendersDefaultSuccessTitleText()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.WithTypeSuccess));
        var component = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal("Success", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersCustomTitleIdAndAriaLabelledBy()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.CustomTitleIdWithTypeSuccess));
        var component = response.QuerySelector(".govuk-notification-banner");
        var title = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal("my-id", component!.GetAttribute("aria-labelledby"));
        Assert.Equal("my-id", title!.Id);
    }

    [Fact]
    public async void HasRoleRegionAttribute()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.WithInvalidType));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Equal("region", component!.GetAttribute("role"));
    }

    [Fact]
    public async void AriaLabelledByAttributeMatchesTheTitleId()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.WithInvalidType));
        var component = response.QuerySelector(".govuk-notification-banner");
        var title = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal(title!.Id, component!.GetAttribute("aria-labelledby"));
    }
}
