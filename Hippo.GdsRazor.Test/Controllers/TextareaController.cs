using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class TextareaController : Controller
{
    private static class Examples
    {
        public static readonly TextareaModel Default = new("more-detail", "more-detail", "Can you provide more detail?");
        public static readonly TextareaModel Classes = new("with-classes", "with-classes", "With classes") {
            Classes = "app-textarea--custom-modifier"
        };
        public static readonly TextareaModel WithDefaultValue = new("full-address", "address", "Full address") {
            Value = "221B Baker Street\nLondon\nNW1 6XE"
        };
        public static readonly TextareaModel Attributes = new("with-attributes", "with-attributes", "With attributes") {
            Attributes = new Dictionary<string, string?> {{"data-attribute", "my data value"}}
        };
        public static readonly TextareaModel WithDescribedBy = new("with-describedby", "with-describedby", "With describedBy") {
            DescribedBy = "some-id"
        };
        public static readonly TextareaModel WithCustomRows = new("full-address", "address", "Full address") {
            Rows = 8
        };
        public static readonly TextareaModel WithOptionalFormGroupClasses = new("textarea-with-page-heading", "address", "Full address") {
            FormGroupClasses = "extra-class"
        };
        public static readonly TextareaModel WithSpellcheckEnabled = new("textarea-with-spellcheck-enabled", "spellcheck", "Spellcheck is enabled") {
            Spellcheck = true
        };
        public static readonly TextareaModel WithSpellcheckDisabled = new("textarea-with-spellcheck-disabled", "spellcheck", "Spellcheck is disabled") {
            Spellcheck = false
        };
        public static readonly TextareaModel WithHint = new("more-detail", "more-detail", "Can you provide more detail?") {
            Hint = "Don't include personal or financial information, eg your National Insurance number or credit card details."
        };
        public static readonly TextareaModel WithHintAndDescribedBy = new("with-hint-describedby", "with-hint-describedby", "With hint and describedBy") {
            DescribedBy = "some-id",
            Hint = "It's on your National Insurance card, benefit letter, payslip or P60. For example, 'QQ 12 34 56 C'."
        };
        public static readonly TextareaModel WithErrorMessage = new("no-ni-reason", "no-ni-reason", "Why can't you provide a National Insurance number?") {
            ErrorMessage = "You must provide an explanation"
        };
        public static readonly TextareaModel WithErrorMessageAndDescribedBy = new("textarea-with-error", "textarea-with-error", "Textarea with error") {
            DescribedBy = "some-id",
            ErrorMessage = "Error message"
        };
        public static readonly TextareaModel WithHintAndErrorMessage = new("with-hint-error", "with-hint-error", "With hint and error") {
            Hint = "Hint",
            ErrorMessage = "Error message"
        };
        public static readonly TextareaModel WithHintErrorMessageAndDescribedBy = new("with-hint-error-describedby", "with-hint-error-describedby", "With hint, error and describedBy") {
            DescribedBy = "some-id",
            Hint = "Hint",
            ErrorMessage = "Error message"
        };
        public static readonly TextareaModel WithLabelAsPageHeading = new(
            "textarea-with-page-heading",
            "address",
            new LabelModel("Can you provide more detail?") {
                Classes = LabelModel.Size.Large,
                IsPageHeading = true
            }
        );
        public static readonly TextareaModel WithAutocompleteAttribute = new("textarea-with-autocomplete-attribute", "address", "Full address") {
            Autocomplete = "street-address"
        };
    }

    private const string PartialName = "GdsTextarea";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult WithDefaultValue() => PartialView(PartialName, Examples.WithDefaultValue);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult WithDescribedBy() => PartialView(PartialName, Examples.WithDescribedBy);
    public IActionResult WithCustomRows() => PartialView(PartialName, Examples.WithCustomRows);
    public IActionResult WithOptionalFormGroupClasses() => PartialView(PartialName, Examples.WithOptionalFormGroupClasses);
    public IActionResult WithSpellcheckEnabled() => PartialView(PartialName, Examples.WithSpellcheckEnabled);
    public IActionResult WithSpellcheckDisabled() => PartialView(PartialName, Examples.WithSpellcheckDisabled);
    public IActionResult WithHint() => PartialView(PartialName, Examples.WithHint);
    public IActionResult WithHintAndDescribedBy() => PartialView(PartialName, Examples.WithHintAndDescribedBy);
    public IActionResult WithErrorMessage() => PartialView(PartialName, Examples.WithErrorMessage);
    public IActionResult WithErrorMessageAndDescribedBy() => PartialView(PartialName, Examples.WithErrorMessageAndDescribedBy);
    public IActionResult WithHintAndErrorMessage() => PartialView(PartialName, Examples.WithHintAndErrorMessage);
    public IActionResult WithHintErrorMessageAndDescribedBy() => PartialView(PartialName, Examples.WithHintErrorMessageAndDescribedBy);
    public IActionResult WithLabelAsPageHeading() => PartialView(PartialName, Examples.WithLabelAsPageHeading);
    public IActionResult WithAutocompleteAttribute() => PartialView(PartialName, Examples.WithAutocompleteAttribute);
    public IActionResult Axe() => View(Examples.Default);
}
