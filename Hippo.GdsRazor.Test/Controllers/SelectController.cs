using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class SelectController : Controller
{
    private static class Examples
    {
        public static readonly SelectModel Default = new(
            "select-1",
            "select-1",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2", Selected = true },
            new SelectModel.ItemModel("GOV.UK frontend option 3") { Value = "3", Disabled = true }
        ) {
            Label = "Label text goes here"
        };
        public static readonly SelectModel WithSelectedValue = new(
            "select-1",
            "select-1",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2", Selected = true },
            new SelectModel.ItemModel("GOV.UK frontend option 3") { Value = "3", Disabled = true }
        ) {
            Label = "Label text goes here",
            Value = "3"
        };
        public static readonly SelectModel ItemSelectedOverridesValue = new(
            "colors",
            "colors",
            new SelectModel.ItemModel("Red") { Value = "red" },
            new SelectModel.ItemModel("Green") { Value = "green", Selected = false },
            new SelectModel.ItemModel("Blue") { Value = "blue" }
        ) {
            Value = "green"
        };
        public static readonly SelectModel WithOptionalFormGroupClasses = new(
            "select-1",
            "select-1",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2", Selected = true },
            new SelectModel.ItemModel("GOV.UK frontend option 3") { Value = "3", Disabled = true }
        ) {
            Label = "Label text goes here",
            Classes = "govuk-!-width-full",
            FormGroupClasses = "extra-class"
        };
        public static readonly SelectModel WithFullWidthOverride = new(
            "select-1",
            "select-1",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2", Selected = true },
            new SelectModel.ItemModel("GOV.UK frontend option 3") { Value = "3", Disabled = true }
        ) {
            Label = "Label text goes here",
            Classes = "govuk-!-width-full"
        };
        public static readonly SelectModel WithDescribedBy = new(
            "with-describedby",
            "with-describedby",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2" }
        ) {
            DescribedBy = "some-id"
        };
        public static readonly SelectModel Attributes = new(
            "with-attributes",
            "with-attributes",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2" }
        ) {
            Attributes = new Dictionary<string, string?> {{"data-attribute", "my data value"}}
        };
        public static readonly SelectModel AttributesOnItems = new(
            "with-item-attributes",
            "with-item-attributes",
            new SelectModel.ItemModel("Option 1") {
                Value = "1",
                Attributes = new Dictionary<string, string?> {{"data-attribute", "ABC"}, {"data-second-attribute", "DEF"}}
            },
            new SelectModel.ItemModel("Option 2") {
                Value = "2",
                Attributes = new Dictionary<string, string?> {{"data-attribute", "GHI"}, {"data-second-attribute", "JKL"}}
            }
        ) {
            Value = "2"
        };
        public static readonly SelectModel Hint = new(
            "select-with-hint",
            "select-with-hint"
        ) {
            Hint = "Hint text goes here"
        };
        public static readonly SelectModel HintAndDescribedBy = new(
            "select-with-hint",
            "select-with-hint",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2" }
        ) {
            DescribedBy = "some-id",
            Hint = "Hint text goes here"
        };
        public static readonly SelectModel Error = new(
            "select-with-error",
            "select-with-error",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2" }
        ) {
            ErrorMessage = "Error message"
        };
        public static readonly SelectModel ErrorAndDescribedBy = new(
            "select-with-error",
            "select-with-error",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2" }
        ) {
            DescribedBy = "some-id",
            ErrorMessage = "Error message"
        };
        public static readonly SelectModel WithHintTextAndErrorMessage = new(
            "select-2",
            "select-2",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2" },
            new SelectModel.ItemModel("GOV.UK frontend option 3") { Value = "3" }
        ) {
            ErrorMessage = "Error message goes here",
            Label = "Label text goes here",
            Hint = "Hint text goes here"
        };
        public static readonly SelectModel WithHintErrorAndDescribedBy = new(
            "select-2",
            "select-2",
            new SelectModel.ItemModel("GOV.UK frontend option 1") { Value = "1" },
            new SelectModel.ItemModel("GOV.UK frontend option 2") { Value = "2" },
            new SelectModel.ItemModel("GOV.UK frontend option 3") { Value = "3" }
        ) {
            DescribedBy = "some-id",
            ErrorMessage = "Error message goes here",
            Label = "Label text goes here",
            Hint = "Hint text goes here"
        };
    }

    private const string PartialName = "GdsSelect";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult WithSelectedValue() => PartialView(PartialName, Examples.WithSelectedValue);
    public IActionResult ItemSelectedOverridesValue() => PartialView(PartialName, Examples.ItemSelectedOverridesValue);
    public IActionResult WithOptionalFormGroupClasses() => PartialView(PartialName, Examples.WithOptionalFormGroupClasses);
    public IActionResult WithFullWidthOverride() => PartialView(PartialName, Examples.WithFullWidthOverride);
    public IActionResult WithDescribedBy() => PartialView(PartialName, Examples.WithDescribedBy);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult AttributesOnItems() => PartialView(PartialName, Examples.AttributesOnItems);
    public IActionResult Hint() => PartialView(PartialName, Examples.Hint);
    public IActionResult HintAndDescribedBy() => PartialView(PartialName, Examples.HintAndDescribedBy);
    public IActionResult Error() => PartialView(PartialName, Examples.Error);
    public IActionResult ErrorAndDescribedBy() => PartialView(PartialName, Examples.ErrorAndDescribedBy);
    public IActionResult WithHintTextAndErrorMessage() => PartialView(PartialName, Examples.WithHintTextAndErrorMessage);
    public IActionResult WithHintErrorAndDescribedBy() => PartialView(PartialName, Examples.WithHintErrorAndDescribedBy);
    public IActionResult Axe() => View(Examples.Default);
}
