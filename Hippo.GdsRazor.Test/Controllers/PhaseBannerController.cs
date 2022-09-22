using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class PhaseBannerController : Controller
{
    private static class Examples
    {
        public static readonly PhaseBannerModel Classes = new("This is a new service – your feedback will help us to improve it") {
            Classes = "extra-class one-more-class"
        };
        public static readonly PhaseBannerModel Text = "This is a new service – your feedback will help us to improve it";
        public static readonly PhaseBannerModel HtmlAsText = "This is a new service - your <a href=\"#\" class=\"govuk-link\">feedback</a> will help us to improve it.";
        public static readonly PhaseBannerModel Attributes = new("This is a new service – your feedback will help us to improve it") {
            Attributes = new Dictionary<string, string?> {{"first-attribute", "foo"}, {"second-attribute", "bar"}}
        };
        public static readonly PhaseBannerModel TagClasses = new("This is a new service – your feedback will help us to improve it") {
            Tag = new TagModel("alpha") {
                Classes = TagModel.Colors.Grey
            }
        };
    }

    private const string PartialName = "GdsPhaseBanner";
    public IActionResult Default() => View();
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Text() => PartialView(PartialName, Examples.Text);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult TagHtml() => View();
    public IActionResult TagClasses() => PartialView(PartialName, Examples.TagClasses);
    public IActionResult Axe() => View();
}
