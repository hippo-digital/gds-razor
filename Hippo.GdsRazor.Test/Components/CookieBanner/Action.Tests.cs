using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CookieBanner;

public class ActionTests : ClientBase<Startup>
{
    public ActionTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersAsButtonByDefault()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.DefaultAction));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-button");

        Assert.IsAssignableFrom<IHtmlButtonElement>(action);
    }

    [Fact]
    public async void RendersAsALinkIfHrefProvided()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Link));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-link");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(action);
    }

    [Fact]
    public async void IgnoresOtherButtonOptionsIfHrefProvided()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.LinkWithFalseButtonOptions));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-link");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(action);
        Assert.Equal("This is a link", action!.TextContent.Trim());
        Assert.Equal("/link", action.GetAttribute("href"));

        Assert.Null(action.GetAttribute("value"));
        Assert.Null(action.GetAttribute("name"));
    }

    [Fact]
    public async void RendersAsALinkButtonIfHrefAndTypeButtonProvided()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.LinkAsAButton));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-button");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(action);
        Assert.Equal("This is a link", action!.TextContent.Trim());
        Assert.Equal("/link", action.GetAttribute("href"));

        Assert.Equal("button", action.GetAttribute("role"));
    }

    [Fact]
    public async void RendersButtonText()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.DefaultAction));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-button");

        Assert.Equal("This is a button", action!.TextContent.Trim());
    }

    [Fact]
    public async void RendersButtonWithCustomType()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Type));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-button");

        Assert.Equal("button", action!.GetAttribute("type"));
    }

    [Fact]
    public async void RendersButtonWithName()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Default));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-button");

        Assert.Equal("cookies", action!.GetAttribute("name"));
    }

    [Fact]
    public async void RendersButtonWithValue()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Default));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-button");

        Assert.Equal("accept", action!.GetAttribute("value"));
    }

    [Fact]
    public async void RendersButtonWithAdditionalClasses()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.ButtonClasses));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-button");

        Assert.Equal("govuk-button my-button-class app-button-class", action!.ClassName);
    }

    [Fact]
    public async void RendersButtonWithAdditionalAttributes()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.ButtonAttributes));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-button");

        Assert.Equal("my-value", action!.GetAttribute("data-button-attribute"));
    }

    [Fact]
    public async void RendersLinkTextAndHref()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.Link));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-link");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(action);
        Assert.Equal("This is a link", action!.TextContent.Trim());
        Assert.Equal("/link", action.GetAttribute("href"));
    }

    [Fact]
    public async void RendersLinkWithAdditionalClasses()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.LinkClasses));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-link");

        Assert.Equal("govuk-link my-link-class app-link-class", action!.ClassName);
    }

    [Fact]
    public async void RendersLinkWithCustomAttributes()
    {
        var response = await Navigate("CookieBanner" ,nameof(CookieBannerController.LinkAttributes));
        var action = response.QuerySelector(".govuk-cookie-banner .govuk-link");

        Assert.Equal("my-value", action!.GetAttribute("data-link-attribute"));
    }
}
