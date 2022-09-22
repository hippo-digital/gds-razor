using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class BreadcrumbsController : Controller
{
    private static class Examples
    {
        public static readonly BreadcrumbsModel Default = new(("/section", "Section"), ("/section/sub-section", "Sub-section"));
        public static readonly BreadcrumbsModel Classes = new("Home") { Classes = "app-breadcrumbs--custom-modifier" };
        public static readonly BreadcrumbsModel Attributes = new("Home") { Id = "my-navigation", Attributes = new Dictionary<string, string?> {{"role", "navigation"}} };
        public static readonly BreadcrumbsModel ItemAttributes = new(
            new LinkModel("Section 1")
            {
                Href = "/section",
                Attributes = new Dictionary<string, string?> {{"data-attribute", "my-attribute"}, {"data-attribute-2", "my-attribute-2"}}
            }
        );
        public static readonly BreadcrumbsModel HtmlAsText = new("<span>Section 1</span>");
        public static readonly BreadcrumbsModel WithLastBreadcrumbAsCurrentPage = new(("/", "Home"), ("/browse/abroad", "Passports, travel and living abroad"), "Travel abroad");
        public static readonly BreadcrumbsModel WithCollapseOnMobile = new(
            ("/", "Home"),
            ("/education", "Education, training and skills"),
            ("/education/special-educational-needs-and-disability-send-and-high-needs", "Special educational needs and disability (SEND) and high needs")
        ) { CollapseOnMobile = true };
    }

    private const string PartialName = "GdsBreadcrumbs";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult ItemAttributes() => PartialView(PartialName, Examples.ItemAttributes);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult Html() => View();
    public IActionResult WithLastBreadcrumbAsCurrentPage() => PartialView(PartialName, Examples.WithLastBreadcrumbAsCurrentPage);
    public IActionResult WithCollapseOnMobile() => PartialView(PartialName, Examples.WithCollapseOnMobile);
    public IActionResult Axe() => View(Examples.Default);
}
