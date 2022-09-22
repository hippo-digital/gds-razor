using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class ErrorSummaryController : Controller
{
    private static class Examples
    {
        public static readonly ErrorSummaryModel Default = new(
            "There is a problem",
            new ErrorSummaryModel.ErrorModel("The date your passport was issued must be in the past") {
                Href = "#example-error-1"
            },
            new ErrorSummaryModel.ErrorModel("Enter a postcode, like AA1 1AA") {
                Href = "#example-error-2"
            }
        );
        public static readonly ErrorSummaryModel WithoutLinks = new(
            "There is a problem",
            "Invalid username or password"
        );
        public static readonly ErrorSummaryModel HtmlAsTitleText = new(
            "Alert, <em>alert</em>",
            "Invalid username or password"
        );
        public static readonly ErrorSummaryModel Description = new(
            "There is a problem",
            "Invalid username or password"
        ) {
            Description = "Lorem ipsum"
        };
        public static readonly ErrorSummaryModel HtmlAsDescriptionText = new(
            "There is a problem",
            "Invalid username or password"
        ) {
            Description = "See <span>errors</span> below"
        };
        public static readonly ErrorSummaryModel Classes = new(
            "There is a problem",
            "Invalid username or password"
        ) {
            Classes = "extra-class one-more-class"
        };
        public static readonly ErrorSummaryModel Attributes = new(
            "This is a problem",
            "Invalid username or password"
        ) {
            Attributes = new Dictionary<string, string?> {{"first-attribute", "foo"}, {"second-attribute", "bar"}}
        };
        public static readonly ErrorSummaryModel ErrorListWithAttributes = new(
            "There is a problem",
            new ErrorSummaryModel.ErrorModel("Error-1") {
                Href = "#item",
                Attributes = new Dictionary<string, string?> {{"data-attribute", "my-attribute"}, {"data-attribute-2", "my-attribute-2"}}
            }
        );
        public static readonly ErrorSummaryModel ErrorListWithHtmlAsText = new(
            "There is a problem",
            "Descriptive link to the <b>question</b> with an error"
        );
        public static readonly ErrorSummaryModel ErrorListWithHtmlAsTextLink = new(
            "There is a problem",
            new ErrorSummaryModel.ErrorModel("Descriptive link to the <b>question</b> with an error") {
                Href = "#error-1"
            }
        );
        public static readonly ErrorSummaryModel AutoFocusDisabled = new("There is a problem") {
            DisableAutoFocus = true
        };
        public static readonly ErrorSummaryModel AutoFocusExplicitlyEnabled = new("There is a problem") {
            DisableAutoFocus = false
        };
    }

    private const string PartialName = "GdsErrorSummary";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult WithoutLinks() => PartialView(PartialName, Examples.WithoutLinks);
    public IActionResult HtmlAsTitleText() => PartialView(PartialName, Examples.HtmlAsTitleText);
    public IActionResult Description() => PartialView(PartialName, Examples.Description);
    public IActionResult HtmlAsDescriptionText() => PartialView(PartialName, Examples.HtmlAsDescriptionText);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult ErrorListWithAttributes() => PartialView(PartialName, Examples.ErrorListWithAttributes);
    public IActionResult ErrorListWithHtmlAsText() => PartialView(PartialName, Examples.ErrorListWithHtmlAsText);
    public IActionResult ErrorListWithHtmlAsTextLink() => PartialView(PartialName, Examples.ErrorListWithHtmlAsTextLink);
    public IActionResult AutoFocusDisabled() => PartialView(PartialName, Examples.AutoFocusDisabled);
    public IActionResult AutoFocusExplicitlyEnabled() => PartialView(PartialName, Examples.AutoFocusExplicitlyEnabled);
    public IActionResult TitleHtml() => View();
    public IActionResult DescriptionHtml() => View();
    public IActionResult ErrorListWithHtml() => View();
    public IActionResult ErrorListWithHtmlLink() => View();
    public IActionResult Axe() => View(Examples.Default);
}
