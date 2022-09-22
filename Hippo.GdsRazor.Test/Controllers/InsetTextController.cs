using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class InsetTextController : Controller
{
    private static class Examples
    {
        public static readonly InsetTextModel Default = "It can take up to 8 weeks to register a lasting power of attorney if there are no mistakes in the application.";
        public static readonly InsetTextModel Classes = new("It can take up to 8 weeks to register a lasting power of attorney if there are no mistakes in the application.") {
            Classes = "app-inset-text--custom-modifier"
        };
        public static readonly InsetTextModel Id = new("It can take up to 8 weeks to register a lasting power of attorney if there are no mistakes in the application.") {
            Id = "my-inset-text"
        };
        public static readonly InsetTextModel HtmlAsText = "It can take <b>up to 8 weeks</b> to register a lasting power of attorney if there are no mistakes in the application.";
        public static readonly InsetTextModel Attributes = new("It can take up to 8 weeks to register a lasting power of attorney if there are no mistakes in the application.") {
            Attributes = new Dictionary<string, string?> {{"data-attribute", "my data value"}}
        };
    }

    private const string PartialName = "GdsInsetText";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult WithHtml() => View();
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Id() => PartialView(PartialName, Examples.Id);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult Axe() => View(Examples.Default);
}
