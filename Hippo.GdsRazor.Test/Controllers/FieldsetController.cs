using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class FieldsetController : Controller
{
    private static class Examples
    {
        public static readonly FieldsetModel Default = new() {
            Legend = "What is your address?"
        };
        public static readonly FieldsetModel AsPageHeadingL = new() {
            Legend = new FieldsetModel.LegendModel("What is your address?") {
                Classes = FieldsetModel.LegendModel.Sizes.Large,
                IsPageHeading = true
            }
        };
        public static readonly FieldsetModel WithDescribedBy = new() {
            DescribedBy = "some-id",
            Legend = "What option?"
        };
        public static readonly FieldsetModel HtmlAsText = new() {
            Legend = "What is <b>your</b> address?"
        };
        public static readonly FieldsetModel LegendClasses = new() {
            Legend = new FieldsetModel.LegendModel("What is your address?") {
                Classes = "my-custom-class"
            }
        };
        public static readonly FieldsetModel Classes = new() {
            Classes = "app-fieldset--custom-modifier",
            Legend = "Which option?"
        };
        public static readonly FieldsetModel Role = new() {
            Role = "group",
            Legend = "Which option?"
        };
        public static readonly FieldsetModel Attributes = new() {
            Attributes = new Dictionary<string, string?> {{"data-attribute", "value"}},
            Legend = "Which option?"
        };
    }

    private const string PartialName = "GdsFieldset";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult WithDescribedBy() => PartialView(PartialName, Examples.WithDescribedBy);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult AsPageHeadingL() => PartialView(PartialName, Examples.AsPageHeadingL);
    public IActionResult LegendClasses() => PartialView(PartialName, Examples.LegendClasses);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Role() => PartialView(PartialName, Examples.Role);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult Html() => View();
    public IActionResult HtmlFieldsetContent() => View();
    public IActionResult Axe() => View(Examples.Default);
}
