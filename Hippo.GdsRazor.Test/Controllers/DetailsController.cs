using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class DetailsController : Controller
{
    private static class Examples
    {
        public static readonly DetailsModel Default = new(
            "Help with nationality",
            "We need to know your nationality so we can work out which elections you're entitled to vote in. " +
            "If you can't provide your nationality, you'll have to send copies of identity documents through the post.");
        public static readonly DetailsModel Expanded = new(
            "Help with nationality",
            "We need to know your nationality so we can work out which elections you're entitled to vote in. " +
            "If you can't provide your nationality, you'll have to send copies of identity documents through the post.")
        {
            Id = "help-with-nationality",
            Open = true
        };
        public static readonly DetailsModel Id = new("Expand this section", "Here are some more details") {
            Id = "my-details-element"
        };
        public static readonly DetailsModel HtmlAsText = new("Expand this section", "More about the greater than symbol (>)");
        public static readonly DetailsModel SummaryHtmlAsText = new("The greater than symbol (>) is the best", "Here are some more details");
        public static readonly DetailsModel Classes = new("Expand me", "Here are some more details") {
            Classes = "some-additional-class"
        };
        public static readonly DetailsModel Attributes = new("Expand me", "Here are some more details") {
            Attributes = new Dictionary<string, string?> {{"data-some-data-attribute", "i-love-data"}, {"another-attribute", "foo"}}
        };
    }

    private const string PartialName = "GdsDetails";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Expanded() => PartialView(PartialName, Examples.Expanded);
    public IActionResult Id() => PartialView(PartialName, Examples.Id);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult Html() => View();
    public IActionResult SummaryHtmlAsText() => PartialView(PartialName, Examples.SummaryHtmlAsText);
    public IActionResult SummaryHtml() => View();
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult Axe() => View(Examples.Default);
}
