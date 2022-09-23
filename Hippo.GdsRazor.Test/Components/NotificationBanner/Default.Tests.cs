using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.NotificationBanner;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("NotificationBanner");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void AriaLabelledByAttributeMatchesTheTitleId()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.Default));
        var banner = response.QuerySelector(".govuk-notification-banner");
        var title = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal(title!.Id, banner!.GetAttribute("aria-labelledby"));
    }

    [Fact]
    public async void HasRoleRegionAttribute()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.Default));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Equal("region", component!.GetAttribute("role"));
    }

    [Fact]
    public async void HasDataModuleAttributeToInitialiseJavaScript()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.Default));
        var component = response.QuerySelector(".govuk-notification-banner");

        Assert.Equal("govuk-notification-banner", component!.GetAttribute("data-module"));
    }

    [Fact]
    public async void RendersHeaderContainer()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.Default));
        var components = response.QuerySelectorAll(".govuk-notification-banner__header");

        Assert.NotEmpty(components);
    }

    [Fact]
    public async void RendersDefaultHeadingLevel()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.Default));
        var component = response.QuerySelector(".govuk-notification-banner__title");

        Assert.IsAssignableFrom<IHtmlHeadingElement>(component);
        Assert.Equal("H2", component!.TagName);
    }

    [Fact]
    public async void RendersDefaultTitleText()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.Default));
        var component = response.QuerySelector(".govuk-notification-banner__title");

        Assert.Equal("Important", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersContent()
    {
        var response = await Navigate("NotificationBanner" ,nameof(NotificationBannerController.Default));
        var component = response.QuerySelector(".govuk-notification-banner__heading");

        Assert.Equal("This publication was withdrawn on 7 March 2014.", component!.TextContent.Trim());
    }
}
