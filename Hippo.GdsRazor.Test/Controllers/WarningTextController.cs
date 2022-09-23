using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class WarningTextController : Controller
{
    private static class Examples
    {
        public static readonly WarningTextModel Default = new("You can be fined up to £5,000 if you don't register.") {
            IconFallbackText = "Warning"
        };
        public static readonly WarningTextModel Attributes = new("You can be fined up to £5,000 if you don't register.") {
            IconFallbackText = "Warning",
            Attributes = new Dictionary<string, string?> {{"data-test", "attribute"}}
        };
        public static readonly WarningTextModel HtmlAsText = new("<span>Some custom warning text</span>") {
            IconFallbackText = "Warning"
        };
        public static readonly WarningTextModel IconFallbackTextOnly = new() {
            IconFallbackText = "Some custom fallback text"
        };
        public static readonly WarningTextModel Classes = new("Warning text") {
            IconFallbackText = "Warning",
            Classes = "govuk-warning-text--custom-class"
        };
    }

    private const string PartialName = "GdsWarningText";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult IconFallbackTextOnly() => PartialView(PartialName, Examples.IconFallbackTextOnly);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Html() => View();
    public IActionResult Axe() => View(Examples.Default);
}
