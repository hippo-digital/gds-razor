using GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace GdsRazorTest.Controllers;

public class CheckboxesController : Controller
{
    private static class Examples
    {
        public static readonly CheckboxesModel Default = new(
            "nationality",
            new CheckboxesModel.ItemModel("british", "British"),
            new CheckboxesModel.ItemModel("irish", "Irish"),
            new CheckboxesModel.ItemModel("other", "Citizen of another country")
        );
        public static readonly CheckboxesModel WithDividerAndNone = new(
            "with-divider-and-none",
            new CheckboxesModel.ItemModel("animal", "Waste from animal carcasses"),
            new CheckboxesModel.ItemModel("mines", "Waste from mines or quarries"),
            new CheckboxesModel.ItemModel("farm", "Farm or agricultural waste"),
            new CheckboxesModel.DividerModel("or"),
            new CheckboxesModel.ItemModel("none", "None of these") { Behaviour = "exclusive" }
        ) {
            Fieldset = new FieldsetModel {
                Legend = new FieldsetModel.LegendModel("Which types of waste do you transport regularly?") {
                    Classes = FieldsetModel.LegendModel.Sizes.Large,
                    IsPageHeading = true
                }
            }
        };
        public static readonly CheckboxesModel Classes = new(
            "example-name",
            new CheckboxesModel.ItemModel("1", "Option 1"),
            new CheckboxesModel.ItemModel("2", "Option 2")
        ) {
            Classes = "app-checkboxes--custom-modifier"
        };
        public static readonly CheckboxesModel WithLabelClasses = new(
            "example-label-classes",
            new CheckboxesModel.ItemModel("yes", "Yes") { Label = new LabelModel { Classes = "bold" } }
        );
        public static readonly CheckboxesModel WithFieldsetDescribedBy = new(
            "example-name",
            new CheckboxesModel.ItemModel("1", "Option 1"),
            new CheckboxesModel.ItemModel("2", "Option 2")
        ) {
            Hint = "If you have dual nationality, select all options that are relevant to you.",
            Fieldset = new FieldsetModel {
                DescribedBy = "some-id",
                Legend = "Which option?"
            }
        };
        public static readonly CheckboxesModel Attributes = new(
            "example-name",
            new CheckboxesModel.ItemModel("1", "Option 1"),
            new CheckboxesModel.ItemModel("2", "Option 2")
        ) {
            Attributes = new Dictionary<string, string?> {{"data-attribute", "value"}, {"data-second-attribute", "second-value"}}
        };
        public static readonly CheckboxesModel WithIdPrefix = new(
            "example-name",
            new CheckboxesModel.ItemModel("1", "Option 1"),
            new CheckboxesModel.ItemModel("2", "Option 2")
        ) {
            IdPrefix = "nationality"
        };
        public static readonly CheckboxesModel WithIdAndName = new(
            "with-id-and-name",
            new CheckboxesModel.ItemModel("yes", "British") {
                Id = "item_british",
                Name = "british"
            },
            new CheckboxesModel.ItemModel("irish", "Irish") {
                Id = "item_irish",
                Name = "irish"
            },
            new CheckboxesModel.ItemModel("scottish", "Scottish") {
                Name = "custom-name-scottish"
            }
        ) {
            Fieldset = new FieldsetModel {
                Legend = "What is your nationality?"
            },
            Hint = "If you have dual nationality, select all options that are relevant to you."
        };
        public static readonly CheckboxesModel WithHintsOnItems = new(
            "with-hints-on-items",
            new CheckboxesModel.ItemModel("gov-gateway", "Sign in with Government Gateway") {
                Id = "government-gateway",
                Name = "gateway",
                Hint = "You'll have a user ID if you've registered for Self Assessment or filed a tax return online before."
            },
            new CheckboxesModel.ItemModel("gov-verify", "Sign in with GOV.UK Verify") {
                Id = "govuk-verify",
                Name = "verify",
                Hint = "You'll have an account if you've already proved your identity with either Barclays, CitizenSafe, Digidentity, Experian, Post Office, Royal Mail or SecureIdentity."
            }
        ) {
            Fieldset = new FieldsetModel {
                Legend = new FieldsetModel.LegendModel("How do you want to sign in?") {
                    Classes = FieldsetModel.LegendModel.Sizes.Large,
                    IsPageHeading = true
                }
            }
        };
        public static readonly CheckboxesModel WithDisabledItem = new(
            "sign-in",
            new CheckboxesModel.ItemModel("gov-gateway", "Sign in with Government Gateway") {
                Id = "government-gateway",
                Name = "gateway",
                Hint = "You'll have a user ID if you've registered for Self Assessment or filed a tax return online before."
            },
            new CheckboxesModel.ItemModel("gov-verify", "Sign in with GOV.UK Verify") {
                Id = "govuk-verify",
                Name = "verify",
                Hint = "You'll have an account if you've already proved your identity with either Barclays, CitizenSafe, Digidentity, Experian, Post Office, Royal Mail or SecureIdentity.",
                Disabled = true
            }
        ) {
            Fieldset = new FieldsetModel {
                Legend = new FieldsetModel.LegendModel("How do you want to sign in?") {
                    Classes = FieldsetModel.LegendModel.Sizes.Large,
                    IsPageHeading = true
                }
            }
        };
        public static readonly CheckboxesModel WithCheckedItem = new(
            "example-name",
            new CheckboxesModel.ItemModel("1", "Option 1"),
            new CheckboxesModel.ItemModel("2", "Option 2") { Checked = true },
            new CheckboxesModel.ItemModel("3", "Option 3") { Checked = true }
        );
        public static readonly CheckboxesModel ItemCheckedOverridesValues = new(
            "colors",
            new CheckboxesModel.ItemModel("red", "Red"),
            new CheckboxesModel.ItemModel("green", "Green") { Checked = false },
            new CheckboxesModel.ItemModel("blue", "Blue")
        ) {
            Values = new List<string> { "red", "green" }
        };
        public static readonly CheckboxesModel ItemsWithAttributes = new(
            "example-name",
            new CheckboxesModel.ItemModel("1", "Option 1") {
                Attributes = new Dictionary<string, string?> {{"data-attribute", "ABC"}, {"data-second-attribute", "DEF"}}
            },
            new CheckboxesModel.ItemModel("2", "Option 2") {
                Attributes = new Dictionary<string, string?> {{"data-attribute", "GHI"}, {"data-second-attribute", "JKL"}}
            }
        );
        public static readonly CheckboxesModel EmptyConditional = new(
            "example-conditional",
            new CheckboxesModel.ItemModel("foo", "Foo") {
                ConditionalContent = null
            }
        );
        public static readonly CheckboxesModel WithErrorMessage = new(
            "waste",
            new CheckboxesModel.ItemModel("animal", "Waste from animal carcasses"),
            new CheckboxesModel.ItemModel("mines", "Waste from mines or quarries"),
            new CheckboxesModel.ItemModel("farm", "Farm or agricultural waste")
        ) {
            Fieldset = new FieldsetModel {
                Legend = "Which types of waste do you transport regularly?"
            },
            ErrorMessage = "Please select an option"
        };
        public static readonly CheckboxesModel WithErrorMessageAndHintsOnItems = new(
            "waste",
            new CheckboxesModel.ItemModel("animal", "Waste from animal carcasses") {
                Hint = "Nullam id dolor id nibh ultricies vehicula ut id elit."
            },
            new CheckboxesModel.ItemModel("mines", "Waste from mines or quarries") {
                Hint = "Nullam id dolor id nibh ultricies vehicula ut id elit."
            },
            new CheckboxesModel.ItemModel("farm", "Farm or agricultural waste") {
                Hint = "Nullam id dolor id nibh ultricies vehicula ut id elit."
            }
        ) {
            Fieldset = new FieldsetModel {
                Legend = "Which types of waste do you transport regularly?"
            },
            ErrorMessage = "Please select an option"
        };
        public static readonly CheckboxesModel WithErrorAndIdPrefix = new(
            "name-of-checkboxes",
            new CheckboxesModel.ItemModel("animal", "Waste from animal carcasses")
        ) {
            IdPrefix = "id-prefix",
            ErrorMessage = "Please select an option"
        };
        public static readonly CheckboxesModel WithErrorMessageAndFieldsetDescribedBy = new(
            "example",
            new CheckboxesModel.ItemModel("british", "British"),
            new CheckboxesModel.ItemModel("irish", "Irish")
        ) {
            Fieldset = new FieldsetModel {
                DescribedBy = "some-id",
                Legend = "What is your nationality?"
            },
            ErrorMessage = "Please select an option"
        };
        public static readonly CheckboxesModel WithFieldsetAndErrorMessage = new(
            "nationality",
            new CheckboxesModel.ItemModel("british", "British"),
            new CheckboxesModel.ItemModel("irish", "Irish"),
            new CheckboxesModel.ItemModel("other", "Citizen of another country")
        ) {
            Fieldset = new FieldsetModel {
                Legend = "What is your nationality?"
            },
            ErrorMessage = "Please accept the terms and conditions"
        };
        public static readonly CheckboxesModel MultipleHints = new(
            "example-multiple-hints",
            new CheckboxesModel.ItemModel("british", "British") { Hint = "Hint for british option here" },
            new CheckboxesModel.ItemModel("irish", "Irish"),
            new CheckboxesModel.ItemModel("other", "Citizen of another country") { Hint = "Hint for other option here" }
        ) {
           Hint = "If you have dual nationality, select all options that are relevant to you."
        };
        public static readonly CheckboxesModel WithErrorMessageAndHint = new(
            "example",
            new CheckboxesModel.ItemModel("british", "British"),
            new CheckboxesModel.ItemModel("irish", "Irish")
        ) {
            Hint = "If you have dual nationality, select all options that are relevant to you.",
            ErrorMessage = "Please select an option",
            Fieldset = new FieldsetModel {
                Legend = "What is your nationality?"
            }
        };
        public static readonly CheckboxesModel WithErrorHintAndFieldsetDescribedBy = new(
            "example",
            new CheckboxesModel.ItemModel("british", "British"),
            new CheckboxesModel.ItemModel("irish", "Irish")
        ) {
            Hint = "If you have dual nationality, select all options that are relevant to you.",
            ErrorMessage = "Please select an option",
            Fieldset = new FieldsetModel {
                DescribedBy = "some-id",
                Legend = "What is your nationality?"
            }
        };
        public static readonly CheckboxesModel FieldsetParams = new(
            "example-name",
            new CheckboxesModel.ItemModel("british", "British"),
            new CheckboxesModel.ItemModel("irish", "Irish")
        ) {
            ErrorMessage = "Please select an option",
            Fieldset = new FieldsetModel {
                Legend = "What is your nationality?",
                Classes = "app-fieldset--custom-modifier",
                Attributes = new Dictionary<string, string?> {{"data-attribute", "value"}, {"data-second-attribute", "second-value"}}
            }
        };
        public static readonly CheckboxesModel WithSingleOptionSetAriaDescribedByOnInput = new(
            "t-and-c",
            new CheckboxesModel.ItemModel("yes", "I agree to the terms and conditions")
        ) {
            ErrorMessage = "Please accept the terms and conditions"
        };
        public static readonly CheckboxesModel WithSingleOptionSetAriaDescribedByOnInputAndDescribedBy = new(
            "t-and-c",
            new CheckboxesModel.ItemModel("yes", "I agree to the terms and conditions")
        ) {
            DescribedBy = "some-id",
            ErrorMessage = "Please accept the terms and conditions"
        };
        public static readonly CheckboxesModel WithSingleOptionAndHintSetAriaDescribedByOnInput = new(
            "t-and-c-with-hint",
            new CheckboxesModel.ItemModel("yes", "I agree to the terms and conditions") {
                Hint = "Go on, you know you want to!"
            }
        ) {
            ErrorMessage = "Please accept the terms and conditions"
        };
        public static readonly CheckboxesModel WithSingleOptionAndHintSetAriaDescribedByOnInputAndDescribedBy = new(
            "t-and-c-with-hint",
            new CheckboxesModel.ItemModel("yes", "I agree to the terms and conditions") {
                Hint = "Go on, you know you want to!"
            }
        ) {
            DescribedBy = "some-id",
            ErrorMessage = "Please accept the terms and conditions"
        };
    }

    public IActionResult Default() => PartialView("GdsCheckboxes", Examples.Default);
    public IActionResult WithDividerAndNone() => PartialView("GdsCheckboxes", Examples.WithDividerAndNone);
    public IActionResult Classes() => PartialView("GdsCheckboxes", Examples.Classes);
    public IActionResult WithLabelClasses() => PartialView("GdsCheckboxes", Examples.WithLabelClasses);
    public IActionResult WithFieldsetDescribedBy() => PartialView("GdsCheckboxes", Examples.WithFieldsetDescribedBy);
    public IActionResult Attributes() => PartialView("GdsCheckboxes", Examples.Attributes);
    public IActionResult WithOptionalFormGroupClassesShowingGroupError() => View();
    public IActionResult WithIdPrefix() => PartialView("GdsCheckboxes", Examples.WithIdPrefix);
    public IActionResult WithIdAndName() => PartialView("GdsCheckboxes", Examples.WithIdAndName);
    public IActionResult WithHintsOnItems() => PartialView("GdsCheckboxes", Examples.WithHintsOnItems);
    public IActionResult WithDisabledItem() => PartialView("GdsCheckboxes", Examples.WithDisabledItem);
    public IActionResult WithCheckedItem() => PartialView("GdsCheckboxes", Examples.WithCheckedItem);
    public IActionResult WithPrecheckedValues() => View();
    public IActionResult ItemCheckedOverridesValues() => PartialView("GdsCheckboxes", Examples.ItemCheckedOverridesValues);
    public IActionResult ItemsWithAttributes() => PartialView("GdsCheckboxes", Examples.ItemsWithAttributes);
    public IActionResult WithConditionalItems() => View();
    public IActionResult WithConditionalItemChecked() => View();
    public IActionResult EmptyConditional() => PartialView("GdsCheckboxes", Examples.EmptyConditional);
    public IActionResult WithErrorMessage() => PartialView("GdsCheckboxes", Examples.WithErrorMessage);
    public IActionResult WithErrorAndIdPrefix() => PartialView("GdsCheckboxes", Examples.WithErrorAndIdPrefix);
    public IActionResult WithFieldsetAndErrorMessage() => PartialView("GdsCheckboxes", Examples.WithFieldsetAndErrorMessage);
    public IActionResult WithErrorMessageAndFieldsetDescribedBy() => PartialView("GdsCheckboxes", Examples.WithErrorMessageAndFieldsetDescribedBy);
    public IActionResult WithErrorMessageAndHintsOnItems() => PartialView("GdsCheckboxes", Examples.WithErrorMessageAndHintsOnItems);
    public IActionResult MultipleHints() => PartialView("GdsCheckboxes", Examples.MultipleHints);
    public IActionResult WithErrorMessageAndHint() => PartialView("GdsCheckboxes", Examples.WithErrorMessageAndHint);
    public IActionResult WithErrorHintAndFieldsetDescribedBy() => PartialView("GdsCheckboxes", Examples.WithErrorHintAndFieldsetDescribedBy);
    public IActionResult FieldsetParams() => PartialView("GdsCheckboxes", Examples.FieldsetParams);
    public IActionResult FieldsetHtmlParams() => View();
    public IActionResult LabelWithAttributes() => View();
    public IActionResult WithSingleOptionSetAriaDescribedByOnInput() => PartialView("GdsCheckboxes", Examples.WithSingleOptionSetAriaDescribedByOnInput);
    public IActionResult WithSingleOptionSetAriaDescribedByOnInputAndDescribedBy() => PartialView("GdsCheckboxes", Examples.WithSingleOptionSetAriaDescribedByOnInputAndDescribedBy);
    public IActionResult WithSingleOptionAndHintSetAriaDescribedByOnInput() => PartialView("GdsCheckboxes", Examples.WithSingleOptionAndHintSetAriaDescribedByOnInput);
    public IActionResult WithSingleOptionAndHintSetAriaDescribedByOnInputAndDescribedBy() => PartialView("GdsCheckboxes", Examples.WithSingleOptionAndHintSetAriaDescribedByOnInputAndDescribedBy);
    public IActionResult Axe() => View(Examples.Default);
}
