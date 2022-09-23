using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class RadiosController : Controller
{
    private static class Examples
    {
        public static readonly RadiosModel Default = new(
            "example-default",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            Hint = "This includes changing your last name or spelling your name differently."
        };
        public static readonly RadiosModel Inline = new(
            "example",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No") { Checked = true }
        ) {
            Hint = "This includes changing your last name or spelling your name differently.",
            Fieldset = new FieldsetModel {
                Legend = "Have you changed your name?"
            },
            IdPrefix = "example",
            Classes = "govuk-radios--inline"
        };
        public static readonly RadiosModel FieldsetWithDescribedBy = new(
            "example-name",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            Hint = "This includes changing your last name or spelling your name differently.",
            Fieldset = new FieldsetModel {
                DescribedBy = "some-id",
                Legend = "Which option?"
            }
        };
        public static readonly RadiosModel Attributes = new(
            "example-name",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            Attributes = new Dictionary<string, string?> {{"data-attribute", "value"}, {"data-second-attribute", "second-value"}}
        };
        public static readonly RadiosModel WithIdPrefix = new(
            "example-radio",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            IdPrefix = "example-id-prefix"
        };
        public static readonly RadiosModel WithDisabled = new(
            "gov",
            new RadiosModel.ItemModel("gateway", "Sign in with Government Gateway") {
                Id = "gateway",
                Hint = "You'll have a user ID if you've registered for Self Assessment or filed a tax return online before."
            },
            new RadiosModel.ItemModel("verify", "Sign in with GOV.UK Verify") {
                Id = "verify",
                Hint = "You'll have an account if you've already proved your identity with either Barclays, CitizenSafe, Digidentity, Experian, Post Office, Royal Mail or SecureIdentity.",
                Disabled = true
            }
        ) {
            IdPrefix = "gov",
            Fieldset = new FieldsetModel {
                Legend = new FieldsetModel.LegendModel("How do you want to sign in?") {
                    Classes = FieldsetModel.LegendModel.Sizes.Large,
                    IsPageHeading = true
                }
            }
        };
        public static readonly RadiosModel Prechecked = new(
            "example-default",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No") { Checked = true }
        ) {
            Hint = "This includes changing your last name or spelling your name differently."
        };
        public static readonly RadiosModel PrecheckedUsingValue = new(
            "example-default",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            Value = "no"
        };
        public static readonly RadiosModel ItemCheckedOverridesValue = new(
            "colors",
            new RadiosModel.ItemModel("red", "Red"),
            new RadiosModel.ItemModel("green", "Green") { Checked = false },
            new RadiosModel.ItemModel("blue", "Blue")
        ) {
            Value = "green"
        };
        public static readonly RadiosModel ItemsWithAttributes = new(
            "example-name",
            new RadiosModel.ItemModel("yes", "Yes") {
                Attributes = new Dictionary<string, string?> {{"data-attribute", "ABC"}, {"data-second-attribute", "DEF"}}
            },
            new RadiosModel.ItemModel("no", "No") {
                Attributes = new Dictionary<string, string?> {{"data-attribute", "GHI"}, {"data-second-attribute", "JKL"}}
            }
        );
        public static readonly RadiosModel WithHintsOnItems = new(
            "gov",
            new RadiosModel.ItemModel("gateway", "Sign in with Government Gateway") {
                Id = "gateway",
                Hint = "You'll have a user ID if you've registered for Self Assessment or filed a tax return online before."
            },
            new RadiosModel.ItemModel("verify", "Sign in with GOV.UK Verify") {
                Id = "verify",
                Hint = "You'll have an account if you've already proved your identity with either Barclays, CitizenSafe, Digidentity, Experian, Post Office, Royal Mail or SecureIdentity."
            }
        ) {
            IdPrefix = "gov",
            Fieldset = new FieldsetModel {
                Legend = new FieldsetModel.LegendModel("How do you want to sign in?") {
                    Classes = FieldsetModel.LegendModel.Sizes.Large,
                    IsPageHeading = true
                }
            }
        };
        public static readonly RadiosModel WithEmptyConditional = new(
            "example-conditional",
            new RadiosModel.ItemModel("yes", "Yes") {
                ConditionalContent = null
            },
            new RadiosModel.ItemModel("no", "No")
        );
        public static readonly RadiosModel WithADivider = new(
            "example",
            new RadiosModel.ItemModel("governement-gateway", "Use Government Gateway"),
            new RadiosModel.ItemModel("govuk-verify", "Use GOV.UK Verify"),
            new RadiosModel.DividerModel { Divider = "or" },
            new RadiosModel.ItemModel("create-account", "Create an account")
        ) {
            IdPrefix = "example-divider",
            Fieldset = new FieldsetModel {
                Legend = "How do you want to sign in?"
            }
        };
        public static readonly RadiosModel LabelWithClasses = new(
            "example-label-classes",
            new RadiosModel.ItemModel("yes", "Yes") {
                Label = new LabelModel {
                    Classes = "bold"
                }
            }
        );
        public static readonly RadiosModel WithHintsOnParentAndItems = new(
            "example-multiple-hints",
            new RadiosModel.ItemModel("yes", "Yes") {
                Hint = "Hint for yes option here"
            },
            new RadiosModel.ItemModel("no", "No") {
                Hint = "Hint for no option here"
            }
        ) {
            Hint = "This includes changing your last name or spelling your name differently.",
            Fieldset = new FieldsetModel {
                Legend = "Have you changed your name?"
            }
        };
        public static readonly RadiosModel WithDescribedByAndHint = new(
            "example-hint-describedby",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            Hint = "This includes changing your last name or spelling your name differently.",
            Fieldset = new FieldsetModel {
                DescribedBy = "some-id",
                Legend = "Have you changed your name?"
            }
        };
        public static readonly RadiosModel WithErrorMessage = new(
            "example-error-message",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            ErrorMessage = "Please select an option"
        };
        public static readonly RadiosModel WithErrorMessageAndIdPrefix = new(
            "example-error-message",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            IdPrefix = "id-prefix",
            ErrorMessage = "Please select an option"
        };
        public static readonly RadiosModel WithFieldsetAndErrorMessage = new(
            "example",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No") { Checked = true }
        ) {
            IdPrefix = "example",
            ErrorMessage = "Please select an option",
            Fieldset = new FieldsetModel {
                Legend = "Have you changed your name?"
            }
        };
        public static readonly RadiosModel WithFieldsetErrorMessageAndDescribedBy = new(
            "example",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No") { Checked = true }
        ) {
            IdPrefix = "example",
            ErrorMessage = "Please select an option",
            Fieldset = new FieldsetModel {
                DescribedBy = "some-id",
                Legend = "Have you changed your name?"
            }
        };
        public static readonly RadiosModel WithHintAndErrorMessage = new(
            "example-error-message-hint",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            Hint = "This includes changing your last name or spelling your name differently.",
            ErrorMessage = "Please select an option",
            Fieldset = new FieldsetModel {
                Legend = "Have you changed your name?"
            }
        };
        public static readonly RadiosModel WithHintErrorMessageAndDescribedBy = new(
            "example-error-message-hint",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            Hint = "This includes changing your last name or spelling your name differently.",
            ErrorMessage = "Please select an option",
            Fieldset = new FieldsetModel {
                DescribedBy = "some-id",
                Legend = "Have you changed your name?"
            }
        };
        public static readonly RadiosModel LabelWithAttributes = new(
            "with-label-attributes",
            new RadiosModel.ItemModel("yes", "Yes") {
                Label = new LabelModel {
                    Attributes = new Dictionary<string, string?> {{"data-attribute", "value"}, {"data-second-attribute", "second-value"}}
                }
            }
        );
        public static readonly RadiosModel FieldsetParams = new(
            "example-fieldset-params",
            new RadiosModel.ItemModel("yes", "Yes"),
            new RadiosModel.ItemModel("no", "No")
        ) {
            Hint = "This includes changing your last name or spelling your name differently.",
            Fieldset = new FieldsetModel {
                Classes = "app-fieldset--custom-modifier",
                Legend = "Have you changed your name?",
                Attributes = new Dictionary<string, string?> {{"data-attribute", "value"}, {"data-second-attribute", "second-value"}}
            }
        };
    }

    private const string PartialName = "GdsRadios";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Inline() => PartialView(PartialName, Examples.Inline);
    public IActionResult FieldsetWithDescribedBy() => PartialView(PartialName, Examples.FieldsetWithDescribedBy);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult WithOptionalFormGroupClassesShowingGroupError() => View();
    public IActionResult WithIdPrefix() => PartialView(PartialName, Examples.WithIdPrefix);
    public IActionResult WithDisabled() => PartialView(PartialName, Examples.WithDisabled);
    public IActionResult Prechecked() => PartialView(PartialName, Examples.Prechecked);
    public IActionResult PrecheckedUsingValue() => PartialView(PartialName, Examples.PrecheckedUsingValue);
    public IActionResult ItemCheckedOverridesValue() => PartialView(PartialName, Examples.ItemCheckedOverridesValue);
    public IActionResult ItemsWithAttributes() => PartialView(PartialName, Examples.ItemsWithAttributes);
    public IActionResult WithHintsOnItems() => PartialView(PartialName, Examples.WithHintsOnItems);
    public IActionResult WithConditionalItems() => View();
    public IActionResult WithConditionalItemsAndPreCheckedValue() => View();
    public IActionResult WithConditionalItemChecked() => View();
    public IActionResult WithEmptyConditional() => PartialView(PartialName, Examples.WithEmptyConditional);
    public IActionResult WithADivider() => PartialView(PartialName, Examples.WithADivider);
    public IActionResult LabelWithClasses() => PartialView(PartialName, Examples.LabelWithClasses);
    public IActionResult WithHintsOnParentAndItems() => PartialView(PartialName, Examples.WithHintsOnParentAndItems);
    public IActionResult WithDescribedByAndHint() => PartialView(PartialName, Examples.WithDescribedByAndHint);
    public IActionResult WithErrorMessage() => PartialView(PartialName, Examples.WithErrorMessage);
    public IActionResult WithErrorMessageAndIdPrefix() => PartialView(PartialName, Examples.WithErrorMessageAndIdPrefix);
    public IActionResult WithFieldsetAndErrorMessage() => PartialView(PartialName, Examples.WithFieldsetAndErrorMessage);
    public IActionResult WithFieldsetErrorMessageAndDescribedBy() => PartialView(PartialName, Examples.WithFieldsetErrorMessageAndDescribedBy);
    public IActionResult WithHintAndErrorMessage() => PartialView(PartialName, Examples.WithHintAndErrorMessage);
    public IActionResult WithHintErrorMessageAndDescribedBy() => PartialView(PartialName, Examples.WithHintErrorMessageAndDescribedBy);
    public IActionResult LabelWithAttributes() => PartialView(PartialName, Examples.LabelWithAttributes);
    public IActionResult FieldsetParams() => PartialView(PartialName, Examples.FieldsetParams);
    public IActionResult FieldsetWithHtml() => View();
    public IActionResult Axe() => View(Examples.Default);
}
