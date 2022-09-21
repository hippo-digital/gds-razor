using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class LabelController : Controller
{
    private static class Examples
    {
        public static readonly LabelModel Default = "National Insurance number";
        public static readonly LabelModel Empty = new();
        public static readonly LabelModel Classes = new("National Insurance number") {
            Classes = "extra-class one-more-class"
        };
        public static readonly LabelModel HtmlAsText = "National Insurance number, <em>NINO</em>";
        public static readonly LabelModel For = new("National Insurance number") {
            For = "#dummy-input"
        };
        public static readonly LabelModel AsPageHeadingL = new("National Insurance number") {
            Classes = LabelModel.Size.Large,
            IsPageHeading = true
        };
        public static readonly LabelModel Attributes = new("National Insurance number") {
            Attributes = new Dictionary<string, string?> {{"first-attribute", "foo"}, {"second-attribute", "bar"}}
        };
    }

    public IActionResult Default() => PartialView("GdsLabel", Examples.Default);
    public IActionResult Empty() => PartialView("GdsLabel", Examples.Empty);
    public IActionResult Classes() => PartialView("GdsLabel", Examples.Classes);
    public IActionResult HtmlAsText() => PartialView("GdsLabel", Examples.HtmlAsText);
    public IActionResult For() => PartialView("GdsLabel", Examples.For);
    public IActionResult AsPageHeadingL() => PartialView("GdsLabel", Examples.AsPageHeadingL);
    public IActionResult Attributes() => PartialView("GdsLabel", Examples.Attributes);
    public IActionResult Html() => View();
    public IActionResult Axe() => View(Examples.Default);
}
