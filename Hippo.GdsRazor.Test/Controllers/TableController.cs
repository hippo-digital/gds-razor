using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class TableController : Controller
{
    private static class Examples
    {
        public static readonly TableModel Default = new(
            new TableModel.RowModel(
                "January",
                new TableModel.CellModel("£85") { Format = "numeric" },
                new TableModel.CellModel("£95") { Format = "numeric" }
            ),
            new TableModel.RowModel(
                "February",
                new TableModel.CellModel("£75") { Format = "numeric" },
                new TableModel.CellModel("£55") { Format = "numeric" }
            ),
            new TableModel.RowModel(
                "March",
                new TableModel.CellModel("£165") { Format = "numeric" },
                new TableModel.CellModel("£125") { Format = "numeric" }
            )
        );
        public static readonly TableModel Classes = new(
            new TableModel.RowModel("Jan"),
            new TableModel.RowModel("Feb")
        ) {
            Classes = "custom-class-goes-here"
        };
        public static readonly TableModel Attributes = new(
            new TableModel.RowModel("Jan"),
            new TableModel.RowModel("Feb")
        ) {
            Attributes = new Dictionary<string, string?> {{"data-foo", "bar"}}
        };
        public static readonly TableModel TableWithHeadAndCaption = new(
            new TableModel.RowModel(
                "January",
                new TableModel.CellModel("£85") { Format = "numeric" },
                new TableModel.CellModel("£95") { Format = "numeric" }
            ),
            new TableModel.RowModel(
                "February",
                new TableModel.CellModel("£75") { Format = "numeric" },
                new TableModel.CellModel("£55") { Format = "numeric" }
            ),
            new TableModel.RowModel(
                "March",
                new TableModel.CellModel("£165") { Format = "numeric" },
                new TableModel.CellModel("£125") { Format = "numeric" }
            )
        ) {
            Caption = "Caption 1: Months and rates",
            CaptionClasses = "govuk-heading-m",
            FirstCellIsHeader = true,
            Head = new TableModel.RowModel(
                "Month you apply",
                new TableModel.CellModel("Rate for bicycles") { Format = "numeric" },
                new TableModel.CellModel("Rate for vehicles") { Format = "numeric" }
            )
        };
        public static readonly TableModel TableWithHead = new(
            new TableModel.RowModel(
                "January",
                new TableModel.CellModel("£85") { Format = "numeric" },
                new TableModel.CellModel("£95") { Format = "numeric" }
            ),
            new TableModel.RowModel(
                "February",
                new TableModel.CellModel("£75") { Format = "numeric" },
                new TableModel.CellModel("£55") { Format = "numeric" }
            ),
            new TableModel.RowModel(
                "March",
                new TableModel.CellModel("£165") { Format = "numeric" },
                new TableModel.CellModel("£125") { Format = "numeric" }
            )
        ) {
            Head = new TableModel.RowModel(
                "Month you apply",
                new TableModel.CellModel("Rate for bicycles") { Format = "numeric" },
                new TableModel.CellModel("Rate for vehicles") { Format = "numeric" }
            )
        };
        public static readonly TableModel HtmlAsText = new(
            new TableModel.RowModel("Foo <script>hacking.do(1337)</script>")
        ) {
            Head = new TableModel.RowModel("Foo <script>hacking.do(1337)</script>")
        };
        public static readonly TableModel HeadWithClasses = new(
            new TableModel.RowModel("Jan"),
            new TableModel.RowModel("Feb")
        ) {
            Head = new TableModel.RowModel(
                new TableModel.CellModel("Foo") {
                    Classes = "my-custom-class"
                }
            )
        };
        public static readonly TableModel HeadWithRowspanAndColspan = new(
            new TableModel.RowModel("Jan"),
            new TableModel.RowModel("Feb")
        ) {
            Head = new TableModel.RowModel(
                new TableModel.CellModel("Foo") { Rowspan = 2, Colspan = 2 }
            )
        };
        public static readonly TableModel HeadWithAttributes = new(
            new TableModel.RowModel("Jan"),
            new TableModel.RowModel("Feb")
        ) {
            Head = new TableModel.RowModel(
                new TableModel.CellModel {
                    Attributes = new Dictionary<string, string?> {{"data-fizz", "buzz"}}
                }
            )
        };
        public static readonly TableModel WithFirstCellIsHeaderTrue = new(
            new TableModel.RowModel(
                "January",
                new TableModel.CellModel("£85") { Format = "numeric" },
                new TableModel.CellModel("£95") { Format = "numeric" }
            ),
            new TableModel.RowModel(
                "February",
                new TableModel.CellModel("£75") { Format = "numeric" },
                new TableModel.CellModel("£55") { Format = "numeric" }
            ),
            new TableModel.RowModel(
                "March",
                new TableModel.CellModel("£165") { Format = "numeric" },
                new TableModel.CellModel("£125") { Format = "numeric" }
            )
        ) {
            FirstCellIsHeader = true
        };
        public static readonly TableModel FirstCellIsHeaderWithHtmlAsText = new(
            new TableModel.RowModel(
                "Foo <script>hacking.do(1337)</script>"
            )
        ) {
            FirstCellIsHeader = true
        };
        public static readonly TableModel FirstCellIsHeaderWithClasses = new(
            new TableModel.RowModel(
                new TableModel.CellModel("Foo") { Classes = "my-custom-class" }
            )
        ) {
            FirstCellIsHeader = true
        };
        public static readonly TableModel FirstCellIsHeaderWithRowspanAndColspan = new(
            new TableModel.RowModel(
                new TableModel.CellModel("Foo") { Rowspan = 2, Colspan = 2 }
            )
        ) {
            FirstCellIsHeader = true
        };
        public static readonly TableModel FirstCellIsHeaderWithAttributes = new(
            new TableModel.RowModel(
                new TableModel.CellModel("Foo") {
                    Attributes = new Dictionary<string, string?> {{"data-fizz", "buzz"}}
                }
            )
        ) {
            FirstCellIsHeader = true
        };
        public static readonly TableModel RowsWithClasses = new(
            new TableModel.RowModel(
                new TableModel.CellModel("Foo") { Classes = "my-custom-class" }
            )
        );
        public static readonly TableModel RowsWithRowspanAndColspan = new(
            new TableModel.RowModel(
                new TableModel.CellModel("Foo") { Rowspan = 2, Colspan = 2 }
            )
        );
        public static readonly TableModel RowsWithAttributes = new(
            new TableModel.RowModel(
                new TableModel.CellModel("Foo") {
                    Attributes = new Dictionary<string, string?> {{"data-fizz", "buzz"}}
                }
            )
        );
    }

    private const string PartialName = "GdsTable";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult TableWithHeadAndCaption() => PartialView(PartialName, Examples.TableWithHeadAndCaption);
    public IActionResult TableWithHead() => PartialView(PartialName, Examples.TableWithHead);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult Html() => View();
    public IActionResult HeadWithClasses() => PartialView(PartialName, Examples.HeadWithClasses);
    public IActionResult HeadWithRowspanAndColspan() => PartialView(PartialName, Examples.HeadWithRowspanAndColspan);
    public IActionResult HeadWithAttributes() => PartialView(PartialName, Examples.HeadWithAttributes);
    public IActionResult WithFirstCellIsHeaderTrue() => PartialView(PartialName, Examples.WithFirstCellIsHeaderTrue);
    public IActionResult FirstCellIsHeaderWithHtmlAsText() => PartialView(PartialName, Examples.FirstCellIsHeaderWithHtmlAsText);
    public IActionResult FirstCellIsHeaderWithHtml() => View();
    public IActionResult FirstCellIsHeaderWithClasses() => PartialView(PartialName, Examples.FirstCellIsHeaderWithClasses);
    public IActionResult FirstCellIsHeaderWithRowspanAndColspan() => PartialView(PartialName, Examples.FirstCellIsHeaderWithRowspanAndColspan);
    public IActionResult FirstCellIsHeaderWithAttributes() => PartialView(PartialName, Examples.FirstCellIsHeaderWithAttributes);
    public IActionResult RowsWithClasses() => PartialView(PartialName, Examples.RowsWithClasses);
    public IActionResult RowsWithRowspanAndColspan() => PartialView(PartialName, Examples.RowsWithRowspanAndColspan);
    public IActionResult RowsWithAttributes() => PartialView(PartialName, Examples.RowsWithAttributes);
    public IActionResult Axe() => View(Examples.Default);
}
