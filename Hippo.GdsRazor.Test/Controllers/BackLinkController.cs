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

    public IActionResult Default() => PartialView("GdsBackLink", Examples.Default);
    public IActionResult Classes() => PartialView("GdsBackLink", Examples.Classes);
    public IActionResult CustomText() => PartialView("GdsBackLink", Examples.CustomText);
    public IActionResult HtmlAsText() => PartialView("GdsBackLink", Examples.HtmlAsText);
    public IActionResult Html() => View();
    public IActionResult Attributes() => View();
    public IActionResult Axe() => View(Examples.Default);
}
