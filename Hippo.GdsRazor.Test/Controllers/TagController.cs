using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class TagController : Controller
{
    private static class Examples
    {
        public static readonly TagModel Default = "alpha";
        public static readonly TagModel Inactive = new("alpha") { Classes = TagModel.Colors.Grey };
        public static readonly TagModel Grey = new("Grey") { Classes = TagModel.Colors.Grey };
        public static readonly TagModel Attributes = new("Tag with attributes") { Id = "my-tag", Attributes = new Dictionary<string, string?> {{"data-test", "attribute"}} };
        public static readonly TagModel HtmlAsText = "<span>alpha</span>";
    }

    public IActionResult Default() => PartialView("GdsTag", Examples.Default);
    public IActionResult Inactive() => PartialView("GdsTag", Examples.Inactive);
    public IActionResult Grey() => PartialView("GdsTag", Examples.Grey);
    public IActionResult Attributes() => PartialView("GdsTag", Examples.Attributes);
    public IActionResult HtmlAsText() => PartialView("GdsTag", Examples.HtmlAsText);
    public IActionResult Html() => View();
    public IActionResult Axe() => View(Examples.Default);
}
