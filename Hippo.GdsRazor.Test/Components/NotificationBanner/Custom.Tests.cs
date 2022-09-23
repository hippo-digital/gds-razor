using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.NotificationBanner;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersCustomTitle()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.CustomTitle));
        var title = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal("Important information", title!.TextContent.Trim());
    }

    [Fact]
    public async void RendersCustomContent()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.CustomText));
        var component = response.QuerySelector(".govuk-notification-banner__heading");

        Assert.Equal("This publication was withdrawn on 7 March 2014.", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersCustomHeadingLevel()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.CustomTitleHeadingLevel));
        var component = response.QuerySelector(".govuk-notification-banner__title");

        Assert.IsAssignableFrom<IHtmlHeadingElement>(component);
        Assert.Equal("H3", component!.TagName);
    }

    [Fact]
    public async void RendersCustomRole()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.CustomRole));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Equal("banner", component!.GetAttribute("role"));
    }

    [Fact]
    public async void RendersAriaLabelledByAttributeMatchingTheTitleIdWhenRoleOverridenToRegion()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.RoleRegionWithTypeSuccess));
        var banner = response.QuerySelector(".govuk-notification-banner");
        var title = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal(title!.Id, banner!.GetAttribute("aria-labelledby"));
    }

    [Fact]
    public async void RendersCustomTitleId()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.CustomTitleId));
        var component = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal("my-id", component!.Id);
    }

    [Fact]
    public async void HasAnAriaLabelledByAttributeMAtchingTheTitleId()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.CustomTitleId));
        var banner = response.QuerySelector(".govuk-notification-banner");

        Assert.Equal("my-id", banner!.GetAttribute("aria-labelledby"));
    }

    [Fact]
    public async void AddsDataDisableAutofocusTrueIfDisableAutofocusIsTrue()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.AutofocusDisabledWithTypeSuccess));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Equal("true", component!.GetAttribute("data-disable-auto-focus"));
    }

    [Fact]
    public async void AddsDataDisableAutofocusFalseIfDisableAutofocusIsFalse()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.AutofocusExplicitlyEnabledWithTypeSuccess));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Equal("false", component!.GetAttribute("data-disable-auto-focus"));
    }

    [Fact]
    public async void RendersClasses()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.Classes));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Contains("app-my-class", component!.ClassList);
    }

    [Fact]
    public async void AllowsAdditionalAttributesToBeAddedToTheComponent()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.Attributes));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Equal("value", component!.GetAttribute("my-attribute"));
    }
}
