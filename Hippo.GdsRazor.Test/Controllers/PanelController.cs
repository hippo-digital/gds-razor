using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class PanelController : Controller
{
    private static class Examples
    {
        public static readonly PanelModel Default = new("Application complete", "Your reference number: HDJ2123F");
        public static readonly PanelModel CustomHeadingLevel = new("Application complete", "Your reference number: HDJ2123F") {
            HeadingLevel = 2
        };
        public static readonly PanelModel TitleHtmlAsText = new("Application <strong>not</strong> complete", "Please complete form 1");
        public static readonly PanelModel BodyHtmlAsText = new("Application complete", "Your reference number<br><strong>HDJ2123F</strong>");
        public static readonly PanelModel Classes = new("Application complete", "Your reference number: HDJ2123F") {
            Classes = "extra-class one-more-class"
        };
        public static readonly PanelModel Attributes = new("Application complete", "Your reference number: HDJ2123F") {
            Attributes = new Dictionary<string, string?> {{"first-attribute", "foo"}, {"second-attribute", "bar"}}
        };
        public static readonly PanelModel TitleWithNoBodyText = new() { Title = "Application complete" };
    }

    private const string PartialName = "GdsPanel";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult TitleWithNoBodyText() => PartialView(PartialName, Examples.TitleWithNoBodyText);
    public IActionResult CustomHeadingLevel() => PartialView(PartialName, Examples.CustomHeadingLevel);
    public IActionResult TitleHtmlAsText() => PartialView(PartialName, Examples.TitleHtmlAsText);
    public IActionResult BodyHtmlAsText() => PartialView(PartialName, Examples.BodyHtmlAsText);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult TitleHtml() => View();
    public IActionResult BodyHtml() => View();
    public IActionResult Axe() => View(Examples.Default);
}
