using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class HintController : Controller
{
    private static class Examples
    {
        public static readonly HintModel Default = "It's on your National Insurance card, benefit letter, payslip or P60. For example, 'QQ 12 34 56 C'.";
        public static readonly HintModel Id = new("It's on your National Insurance card, benefit letter, payslip or P60.") {
            Id = "my-hint"
        };
        public static readonly HintModel Classes = new("It's on your National Insurance card, benefit letter, payslip or P60.") {
            Id = "example-hint",
            Classes = "app-hint--custom-modifier"
        };
        public static readonly HintModel HtmlAsText = "Unexpected <strong>bold text</strong> in body";
        public static readonly HintModel Attributes = new("It's on your National Insurance card, benefit letter, payslip or P60.") {
            Attributes = new Dictionary<string, string?> {{"data-attribute", "my data value"}}
        };
    }

    private const string PartialName = "GdsHint";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Id() => PartialView(PartialName, Examples.Id);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult Html() => View();
    public IActionResult Axe() => View(Examples.Default);
}
