using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class NotificationBannerController : Controller
{
    private static class Examples
    {
        public static readonly NotificationBannerModel Default = new("This publication was withdrawn on 7 March 2014.");
        public static readonly NotificationBannerModel CustomTitle = new("This publication was withdrawn on 7 March 2014.") {
            Title = "Important information"
        };
        public static readonly NotificationBannerModel CustomText = new("This publication was withdrawn on 7 March 2014.");
        public static readonly NotificationBannerModel CustomTitleHeadingLevel = new("This publication was withdrawn on 7 March 2014.") {
            TitleHeadingLevel = 3
        };
        public static readonly NotificationBannerModel CustomRole = new("This publication was withdrawn on 7 March 2014.") {
            Role = "banner"
        };
        public static readonly NotificationBannerModel RoleRegionWithTypeSuccess = new("Email sent to example@email.com") {
            Type = "success",
            Role = "region"
        };
        public static readonly NotificationBannerModel CustomTitleId = new("This publication was withdrawn on 7 March 2014.") {
            TitleId = "my-id"
        };
        public static readonly NotificationBannerModel AutofocusDisabledWithTypeSuccess = new("Email sent to example@email.com") {
            Type = "success",
            DisableAutoFocus = true
        };
        public static readonly NotificationBannerModel AutofocusExplicitlyEnabledWithTypeSuccess = new("Email sent to example@email.com") {
            Type = "success",
            DisableAutoFocus = false
        };
        public static readonly NotificationBannerModel Classes = new("This publication was withdrawn on 7 March 2014.") {
            Classes = "app-my-class"
        };
        public static readonly NotificationBannerModel Attributes = new("This publication was withdrawn on 7 March 2014.") {
            Attributes = new Dictionary<string, string?> {{"my-attribute", "value"}}
        };
        public static readonly NotificationBannerModel TitleHtmlAsText = new("This publication was withdrawn on 7 March 2014.") {
            Title = "<span>Important information</span>"
        };
        public static readonly NotificationBannerModel HtmlAsText = new("<span>This publication was withdrawn on 7 March 2014.</span>");
        public static readonly NotificationBannerModel WithTypeSuccess = new("Email sent to example@email.com") {
            Type = "success"
        };
        public static readonly NotificationBannerModel CustomTitleIdWithTypeSuccess = new("Email sent to example@email.com") {
            Type = "success",
            TitleId = "my-id"
        };
        public static readonly NotificationBannerModel WithInvalidType = new("This publication was withdrawn on 7 March 2014.") {
            Type = "some-type"
        };
    }

    private const string PartialName = "GdsNotificationBanner";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult CustomTitle() => PartialView(PartialName, Examples.CustomTitle);
    public IActionResult CustomText() => PartialView(PartialName, Examples.CustomText);
    public IActionResult CustomTitleHeadingLevel() => PartialView(PartialName, Examples.CustomTitleHeadingLevel);
    public IActionResult CustomRole() => PartialView(PartialName, Examples.CustomRole);
    public IActionResult RoleRegionWithTypeSuccess() => PartialView(PartialName, Examples.RoleRegionWithTypeSuccess);
    public IActionResult CustomTitleId() => PartialView(PartialName, Examples.CustomTitleId);
    public IActionResult AutofocusDisabledWithTypeSuccess() => PartialView(PartialName, Examples.AutofocusDisabledWithTypeSuccess);
    public IActionResult AutofocusExplicitlyEnabledWithTypeSuccess() => PartialView(PartialName, Examples.AutofocusExplicitlyEnabledWithTypeSuccess);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult TitleHtmlAsText() => PartialView(PartialName, Examples.TitleHtmlAsText);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult WithTypeSuccess() => PartialView(PartialName, Examples.WithTypeSuccess);
    public IActionResult CustomTitleIdWithTypeSuccess() => PartialView(PartialName, Examples.CustomTitleIdWithTypeSuccess);
    public IActionResult WithInvalidType() => PartialView(PartialName, Examples.WithInvalidType);
    public IActionResult TitleAsHtml() => View();
    public IActionResult WithTextAsHtml() => View();
    public IActionResult Axe() => View(Examples.Default);
}
