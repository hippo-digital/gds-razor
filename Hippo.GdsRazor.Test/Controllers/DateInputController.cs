using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class DateInputController : Controller
{
    private static class Examples
    {
        public static readonly DateInputModel Default = new("dob");
        public static readonly DateInputModel CompleteQuestion = new("dob") {
            NamePrefix = "dob",
            Fieldset = new FieldsetModel {
                Legend = "What is your date of birth?"
            },
            Hint = "For example, 31 3 1980",
            Items = new List<DateInputModel.ItemModel> {
                new("day") { Classes = InputModel.Width.Width2 },
                new("month") { Classes = InputModel.Width.Width2 },
                new("year") { Classes = InputModel.Width.Width4 }
            }
        };
        public static readonly DateInputModel WithErrorsOnly = new("dob-errors") {
            Fieldset = new FieldsetModel {
                Legend = "What is your date of birth?"
            },
            ErrorMessage = "Error message goes here",
            Items = new List<DateInputModel.ItemModel> {
                new("day") { Classes = InputModel.Width.Width2 + " govuk-input--error" },
                new("month") { Classes = InputModel.Width.Width2 + " govuk-input--error" },
                new("year") { Classes = InputModel.Width.Width4 + " govuk-input--error" }
            }
        };
        public static readonly DateInputModel WithErrorsAndHint = new("dob-errors") {
            Fieldset = new FieldsetModel {
                Legend = "What is your date of birth?"
            },
            Hint = "For example, 31 3 1980",
            ErrorMessage = "Error message goes here",
            Items = new List<DateInputModel.ItemModel> {
                new("day") { Classes = InputModel.Width.Width2 + " govuk-input--error" },
                new("month") { Classes = InputModel.Width.Width2 + " govuk-input--error" },
                new("year") { Classes = InputModel.Width.Width4 + " govuk-input--error" }
            }
        };
        public static readonly DateInputModel WithOptionalFormGroupClasses = new("dob") {
            NamePrefix = "dob",
            Fieldset = new FieldsetModel {
                Legend = "What is your date of birth?"
            },
            Hint = "For example, 31 3 1980",
            FormGroupClasses = "extra-class"
        };
        public static readonly DateInputModel WithAutocompleteValues = new("dob-with-autocomplete-attribute") {
            NamePrefix = "dob-with-autocomplete",
            Fieldset = new FieldsetModel {
                Legend = "What is your date of birth?"
            },
            Hint = "For example, 31 3 1980",
            Items = new List<DateInputModel.ItemModel> {
                new("day") {
                    Classes = InputModel.Width.Width2,
                    Autocomplete = "bday-day"
                },
                new("month") {
                    Classes = InputModel.Width.Width2,
                    Autocomplete = "bday-month"
                },
                new("year") {
                    Classes = InputModel.Width.Width4,
                    Autocomplete = "bday-year"
                }
            }
        };
        public static readonly DateInputModel WithInputAttributes = new("dob-with-input-attributes") {
            NamePrefix = "dob-with-input-attributes",
            Fieldset = new FieldsetModel {
                Legend = "What is your date of birth?"
            },
            Hint = "For example, 31 3 1980",
            Items = new List<DateInputModel.ItemModel> {
                new("day") {
                    Classes = InputModel.Width.Width2,
                    Attributes = new Dictionary<string, string?> {{"data-example-day", "day"}}
                },
                new("month") {
                    Classes = InputModel.Width.Width2,
                    Attributes = new Dictionary<string, string?> {{"data-example-month", "month"}}
                },
                new("year") {
                    Classes = InputModel.Width.Width4,
                    Attributes = new Dictionary<string, string?> {{"data-example-year", "year"}}
                }
            }
        };
        public static readonly DateInputModel Classes = new("with-classes") {
            Classes = "app-date-input--custom-modifier"
        };
        public static readonly DateInputModel Attributes = new("with-attributes") {
            Attributes = new Dictionary<string, string?> {{"data-attribute", "my data value"}}
        };
        public static readonly DateInputModel WithEmptyItems = new("dob") {
            Items = new List<DateInputModel.ItemModel>()
        };
        public static readonly DateInputModel CustomPattern = new("with-custom-pattern") {
            Items = new List<DateInputModel.ItemModel> {
                new("day") {
                    Pattern = "[0-8]*"
                }
            }
        };
        public static readonly DateInputModel CustomInputmode = new("with-custom-inputmode") {
            Items = new List<DateInputModel.ItemModel> {
                new("day") {
                    Pattern = "[0-9X]*",
                    Inputmode = "text"
                }
            }
        };
        public static readonly DateInputModel WithNestedName = new("dob") {
            Items = new List<DateInputModel.ItemModel> {
                new("day[dd]"),
                new("month[mm]"),
                new("year[yyyy]")
            }
        };
        public static readonly DateInputModel WithIdOnItems = new("with-item-id") {
            Items = new List<DateInputModel.ItemModel> {
                new("day") { Id = "day" },
                new("month") { Id = "month" },
                new("year") { Id = "year" }
            }
        };
        public static readonly DateInputModel SuffixedId = new("my-date-input") {
            Items = new List<DateInputModel.ItemModel> {
                new("day"),
                new("month"),
                new("year")
            }
        };
        public static readonly DateInputModel WithValues = new("with-values") {
            Items = new List<DateInputModel.ItemModel> {
                new("day") { Id = "day" },
                new("month") { Id = "month" },
                new("year") { Id = "year", Value = "2018" }
            }
        };
        public static readonly DateInputModel WithHintAndDescribedBy = new("dob-errors") {
            Fieldset = new FieldsetModel {
                DescribedBy = "some-id",
                Legend = "What is your date of birth?"
            },
            Hint = "For example, 31 3 1980"
        };
        public static readonly DateInputModel WithErrorAndDescribedBy = new("dob-errors") {
            Fieldset = new FieldsetModel {
                DescribedBy = "some-id",
                Legend = "What is your date of birth?"
            },
            ErrorMessage = "Error message goes here"
        };
        public static readonly DateInputModel ItemsWithClasses = new("with-item-classes") {
            Items = new List<DateInputModel.ItemModel> {
                new("day") { Classes = "app-date-input__day" },
                new("month") { Classes = "app-date-input__month" },
                new("year") { Classes = "app-date-input__year" }
            }
        };
        public static readonly DateInputModel ItemsWithoutClasses = new("without-item-classes") {
            Items = new List<DateInputModel.ItemModel> {
                new("day"),
                new("month"),
                new("year")
            }
        };
    }

    private const string PartialName = "GdsDateInput";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult CompleteQuestion() => PartialView(PartialName, Examples.CompleteQuestion);
    public IActionResult WithErrorsOnly() => PartialView(PartialName, Examples.WithErrorsOnly);
    public IActionResult WithErrorsAndHint() => PartialView(PartialName, Examples.WithErrorsAndHint);
    public IActionResult WithOptionalFormGroupClasses() => PartialView(PartialName, Examples.WithOptionalFormGroupClasses);
    public IActionResult WithAutocompleteValues() => PartialView(PartialName, Examples.WithAutocompleteValues);
    public IActionResult WithInputAttributes() => PartialView(PartialName, Examples.WithInputAttributes);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult WithEmptyItems() => PartialView(PartialName, Examples.WithEmptyItems);
    public IActionResult CustomPattern() => PartialView(PartialName, Examples.CustomPattern);
    public IActionResult CustomInputmode() => PartialView(PartialName, Examples.CustomInputmode);
    public IActionResult WithNestedName() => PartialView(PartialName, Examples.WithNestedName);
    public IActionResult WithIdOnItems() => PartialView(PartialName, Examples.WithIdOnItems);
    public IActionResult SuffixedId() => PartialView(PartialName, Examples.SuffixedId);
    public IActionResult WithValues() => PartialView(PartialName, Examples.WithValues);
    public IActionResult WithHintAndDescribedBy() => PartialView(PartialName, Examples.WithHintAndDescribedBy);
    public IActionResult WithErrorAndDescribedBy() => PartialView(PartialName, Examples.WithErrorAndDescribedBy);
    public IActionResult ItemsWithClasses() => PartialView(PartialName, Examples.ItemsWithClasses);
    public IActionResult ItemsWithoutClasses() => PartialView(PartialName, Examples.ItemsWithoutClasses);
    public IActionResult FieldsetHtml() => View();
    public IActionResult Axe() => View(Examples.Default);
}
