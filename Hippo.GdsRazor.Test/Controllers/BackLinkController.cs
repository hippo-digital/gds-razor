using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class BackLinkController : Controller
{
    private static class Examples
    {
        public static readonly BackLinkModel Default = new("#");
        public static readonly BackLinkModel Classes = new("#") { Classes = "app-back-link--custom-class" };
        public static readonly BackLinkModel CustomText = new("#") { Content = "Back to home" };
        public static readonly BackLinkModel HtmlAsText = new("#") { Content = "<b>Home</b>" };
    }

    private const string PartialName = "GdsBackLink";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult CustomText() => PartialView(PartialName, Examples.CustomText);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult Html() => View();
    public IActionResult Attributes() => View();
    public IActionResult Axe() => View(Examples.Default);
}
