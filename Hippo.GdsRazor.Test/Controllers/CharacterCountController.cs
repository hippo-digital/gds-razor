using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class CharacterCountController : Controller
{
    private static class Examples
    {
        public static readonly CharacterCountModel Default = new("more-detail", "more-detail", "Can you provide more detail?")
        {
            MaxLength = 10
        };
        public static readonly CharacterCountModel WithHint = new("with-hint", "with-hint", "Can you provide more detail?")
        {
            MaxLength = 10,
            Hint = "Don't include personal or financial information, eg your National Insurance number or credit card details."
        };
        public static readonly CharacterCountModel WithDefaultValue = new("with-default-value", "default-value", "Full address")
        {
            MaxLength = 100,
            Value = "221B Baker Street\nLondon\nNW1 6XE"
        };
        public static readonly CharacterCountModel WithDefaultValueExceedingLimit = new("exceeding-characters", "exceeding", "Full address")
        {
            MaxLength = 10,
            Value = "221B Baker Street\nLondon\nNW1 6XE",
            ErrorMessage = "Please do not exceed the maximum allowed limit"
        };
        public static readonly CharacterCountModel WithCustomRows = new("custom-rows", "custom", "Full address")
        {
            MaxLength = 10,
            Rows = 8
        };
        public static readonly CharacterCountModel WithWordCount = new("word-count", "word-count", "Full address")
        {
            MaxWords = 10
        };
        public static readonly CharacterCountModel WithThreshold = new("word-threshold", "word-threshold", "Full address")
        {
            MaxWords = 10,
            Threshold = 75
        };
        public static readonly CharacterCountModel Classes = new("with-classes", "with-classes", "With classes")
        {
            MaxLength = 10,
            Classes = "app-character-count--custom-modifier"
        };
        public static readonly CharacterCountModel Attributes = new("with-attributes", "with-attributes", "With attributes")
        {
            MaxLength = 10,
            Attributes = new Dictionary<string, string?> {{"data-attribute", "my data value"}}
        };
        public static readonly CharacterCountModel FormGroupWithClasses = new("with-formgroup", "with-formgroup", "With formgroup")
        {
            MaxLength = 10,
            FormGroupClasses = "app-character-count--custom-modifier"
        };
        public static readonly CharacterCountModel CustomClassesOnCountMessage = new("with-custom-countmessage-class", "with-custom-countmessage-class", "With custom countMessage class")
        {
            MaxLength = 10,
            CountMessageClasses = "app-custom-count-message"
        };
        public static readonly CharacterCountModel SpellcheckEnabled = new("with-spellcheck", "with-spellcheck", "With spellcheck")
        {
            MaxLength = 10,
            Spellcheck = true
        };
        public static readonly CharacterCountModel SpellcheckDisabled = new("without-spellcheck", "without-spellcheck", "Without spellcheck")
        {
            MaxLength = 10,
            Spellcheck = false
        };
        public static readonly CharacterCountModel CustomClassesWithErrorMessage = new("with-custom-error-class", "with-custom-error-class", "With custom error class")
        {
            MaxLength = 10,
            Classes = "app-character-count--custom-modifier",
            ErrorMessage = "Error message"
        };
    }

    private const string PartialName = "GdsCharacterCount";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult WithHint() => PartialView(PartialName, Examples.WithHint);
    public IActionResult WithDefaultValue() => PartialView(PartialName, Examples.WithDefaultValue);
    public IActionResult WithDefaultValueExceedingLimit() => PartialView(PartialName, Examples.WithDefaultValueExceedingLimit);
    public IActionResult WithCustomRows() => PartialView(PartialName, Examples.WithCustomRows);
    public IActionResult WithWordCount() => PartialView(PartialName, Examples.WithWordCount);
    public IActionResult WithThreshold() => PartialView(PartialName, Examples.WithThreshold);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult FormGroupWithClasses() => PartialView(PartialName, Examples.FormGroupWithClasses);
    public IActionResult CustomClassesOnCountMessage() => PartialView(PartialName, Examples.CustomClassesOnCountMessage);
    public IActionResult SpellcheckEnabled() => PartialView(PartialName, Examples.SpellcheckEnabled);
    public IActionResult SpellcheckDisabled() => PartialView(PartialName, Examples.SpellcheckDisabled);
    public IActionResult CustomClassesWithErrorMessage() => PartialView(PartialName, Examples.CustomClassesWithErrorMessage);
    public IActionResult Axe() => View(Examples.Default);
}
