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

    public IActionResult Default() => PartialView("GdsInsetText", Examples.Default);
    public IActionResult WithHtml() => View();
    public IActionResult Classes() => PartialView("GdsInsetText", Examples.Classes);
    public IActionResult Id() => PartialView("GdsInsetText", Examples.Id);
    public IActionResult HtmlAsText() => PartialView("GdsInsetText", Examples.HtmlAsText);
    public IActionResult Attributes() => PartialView("GdsInsetText", Examples.Attributes);
    public IActionResult Axe() => View(Examples.Default);
}
