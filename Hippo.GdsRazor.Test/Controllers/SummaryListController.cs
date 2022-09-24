using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class SummaryListController : Controller
{
    private static class Examples
    {
        public static readonly SummaryListModel Attributes = new(
            new SummaryListModel.RowModel("Name", "Firstname Lastname")
        ) {
            Attributes = new Dictionary<string, string?> {{"data-attribute-1", "value-1"}, {"data-attribute-2", "value-2"}}
        };
        public static readonly SummaryListModel RowsWithClasses = new(
            new SummaryListModel.RowModel("Name", "Firstname Lastname") {
                Classes = "app-custom-class"
            }
        );
        public static readonly SummaryListModel KeyWithClasses = new(
            new SummaryListModel.RowModel(
                new SummaryListModel.ItemModel("Name") {
                    Classes = "app-custom-class"
                },
                "Firstname Lastname"
            )
        );
        public static readonly SummaryListModel ActionsHref = new(
            new SummaryListModel.RowModel("Name", "Firstname Lastname") {
                Actions = new List<SummaryListModel.ActionModel> {
                    new("https://www.gov.uk", "Go to GOV.UK")
                }
            }
        );
        public static readonly SummaryListModel ActionsWithClasses = new(
            new SummaryListModel.RowModel("Name", "Firstname Lastname") {
                Actions = new List<SummaryListModel.ActionModel> {
                    new("/edit", "Edit")
                },
                ActionsClasses = "app-custom-class"
            }
        );
        public static readonly SummaryListModel ActionsWithAttributes = new(
            new SummaryListModel.RowModel("Name", "Firstname Lastname") {
                Actions = new List<SummaryListModel.ActionModel> {
                    new("/edit", "Edit") {
                        Attributes = new Dictionary<string, string?> {{"data-test-attribute", "value"}, {"data-test-attribute-2", "value-2"}}
                    }
                }
            }
        );
        public static readonly SummaryListModel SingleActionWithAnchor = new(
            new SummaryListModel.RowModel("Name", "Firstname Lastname") {
                Actions = new List<SummaryListModel.ActionModel> {
                    new("#", "First action")
                }
            }
        );
        public static readonly SummaryListModel ClassesOnItems = new(
            new SummaryListModel.RowModel("Name", "Firstname Lastname") {
                Actions = new List<SummaryListModel.ActionModel> {
                    new("#", "Edit") {
                        Classes = "govuk-link--no-visited-state"
                    }
                }
            }
        );
        public static readonly SummaryListModel EmptyItemsArray = new(
            new SummaryListModel.RowModel("Name", "Firstname Lastname") {
                Actions = new List<SummaryListModel.ActionModel>()
            }
        );
    }

    private const string PartialName = "GdsSummaryList";
    public IActionResult Default() => View();
    public IActionResult NoBorder() => View();
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult RowsWithClasses() => PartialView(PartialName, Examples.RowsWithClasses);
    public IActionResult KeyWithHtml() => View();
    public IActionResult KeyWithClasses() => PartialView(PartialName, Examples.KeyWithClasses);
    public IActionResult ValueWithHtml() => View();
    public IActionResult OverridenWidths() => View();
    public IActionResult ActionsHref() => PartialView(PartialName, Examples.ActionsHref);
    public IActionResult WithActions() => View();
    public IActionResult ActionsWithHtml() => View();
    public IActionResult Translated() => View();
    public IActionResult ActionsWithClasses() => PartialView(PartialName, Examples.ActionsWithClasses);
    public IActionResult ActionsWithAttributes() => PartialView(PartialName, Examples.ActionsWithAttributes);
    public IActionResult SingleActionWithAnchor() => PartialView(PartialName, Examples.SingleActionWithAnchor);
    public IActionResult WithSomeActions() => View();
    public IActionResult ClassesOnItems() => PartialView(PartialName, Examples.ClassesOnItems);
    public IActionResult EmptyItemsArray() => PartialView(PartialName, Examples.EmptyItemsArray);

    public IActionResult Axe() => View("Axe", nameof(Default));
    public IActionResult AxeSomeActions() => View("Axe", nameof(WithSomeActions));
}
