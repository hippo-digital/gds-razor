using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class SkipLinkController : Controller
{
    private static class Examples
    {
        public static readonly SkipLinkModel Default = new("Skip to main content") { Href = "#content" };
        public static readonly SkipLinkModel NoHref = "Skip to main content";
        public static readonly SkipLinkModel CustomHref = new("Skip to custom content") { Href = "#custom" };
        public static readonly SkipLinkModel CustomText = "skip";
        public static readonly SkipLinkModel HtmlAsText = "<p>skip</p>";
        public static readonly SkipLinkModel Classes = new("Skip link") { Classes = "app-skip-link--custom-class" };
        public static readonly SkipLinkModel Attributes = new("Skip link") {
            Attributes = new Dictionary<string, string?> {{"data-test", "attribute"}, {"aria-label", "Skip to content"}}
        };
    }

    private const string PartialName = "GdsSkipLink";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult NoHref() => PartialView(PartialName, Examples.NoHref);
    public IActionResult CustomHref() => PartialView(PartialName, Examples.CustomHref);
    public IActionResult CustomText() => PartialView(PartialName, Examples.CustomText);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult Html() => View();
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult Axe() => View(Examples.Default);
}
