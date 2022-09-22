using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class ErrorMessageController : Controller
{
    private static class Examples
    {
        public static readonly ErrorMessageModel Default = "Error message about full name goes here";
        public static readonly ErrorMessageModel Id = new("This is an error message") {
            Id = "my-error-message-id"
        };
        public static readonly ErrorMessageModel Classes = new("This is an error message") {
            Classes = "custom-class"
        };
        public static readonly ErrorMessageModel HtmlAsText = "Unexpected > in body";
        public static readonly ErrorMessageModel Attributes = new("This is an error message") {
            Attributes = new Dictionary<string, string?> {{"data-test", "attribute"}}
        };
        public static readonly ErrorMessageModel WithVisuallyHiddenText = new("Rhowch eich enw llawn") {
            VisuallyHiddenText = "Gwall"
        };
        public static readonly ErrorMessageModel VisuallyHiddenTextRemoved = new("There is an error on line 42") {
            VisuallyHiddenText = ""
        };
    }

    private const string PartialName = "GdsErrorMessage";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Id() => PartialView(PartialName, Examples.Id);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult WithVisuallyHiddenText() => PartialView(PartialName, Examples.WithVisuallyHiddenText);
    public IActionResult VisuallyHiddenTextRemoved() => PartialView(PartialName, Examples.VisuallyHiddenTextRemoved);
    public IActionResult Html() => View();
    public IActionResult Translated() => View();
    public IActionResult Axe() => View(Examples.Default);
}
