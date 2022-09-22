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

    private const string PartialName = "GdsLabel";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Empty() => PartialView(PartialName, Examples.Empty);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult For() => PartialView(PartialName, Examples.For);
    public IActionResult AsPageHeadingL() => PartialView(PartialName, Examples.AsPageHeadingL);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult Html() => View();
    public IActionResult Axe() => View(Examples.Default);
}
