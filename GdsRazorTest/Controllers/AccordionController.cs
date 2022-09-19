using GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace GdsRazorTest.Controllers;

public class AccordionController : Controller
{
    private static class Examples
    {
        public static readonly AccordionModel Classes = new(
            "accordion-classes",
            new AccordionModel.ItemModel(
                "Section A",
                "Some content"
            )
        ) {
            Classes = "myClass"
        };

        public static readonly AccordionModel Attributes = new(
            "accordion-attributes",
            new AccordionModel.ItemModel(
                "Section A",
                "Some content"
            )
        ) {
            Attributes = new Dictionary<string, string?> {{"data-attribute", "value"}}
        };

        public static readonly AccordionModel CustomHeadingLevel = new(
            "accordion-heading",
            new AccordionModel.ItemModel(
                "Section A",
                "Some content"
            )
        ) {
            HeadingLevel = 3
        };
    }

    public IActionResult Default() => View();
    public IActionResult Classes() => PartialView("GdsAccordion", Examples.Classes);
    public IActionResult Attributes() => PartialView("GdsAccordion", Examples.Attributes);
    public IActionResult CustomHeadingLevel() => PartialView("GdsAccordion", Examples.CustomHeadingLevel);
    public IActionResult HeadingHtml() => View();
    public IActionResult WithOneSectionOpen() => View();
    public IActionResult WithAdditionalDescriptions() => View();
    public IActionResult WithTranslations() => View();
    public IActionResult Axe() => View();
}
