using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class TabsController : Controller
{
    private static class Examples
    {
        public static readonly TabsModel Classes = new(
            new TabsModel.ItemModel("tab-1", "Tab 1", "Information about tabs")
        ) {
            Classes = "app-tabs--custom-modifier"
        };
        public static readonly TabsModel Id = new(
            new TabsModel.ItemModel("tab-1", "Tab 1", "Information about tabs")
        ) {
            Id = "my-tabs"
        };
        public static readonly TabsModel Title = new(
            new TabsModel.ItemModel("tab-1", "Tab 1", "Information about tabs")
        ) {
            Title = "Custom title for Contents"
        };
        public static readonly TabsModel Attributes = new(
            new TabsModel.ItemModel("tab-1", "Tab 1", "Information about tabs")
        ) {
            Attributes = new Dictionary<string, string?> {{"data-attribute", "my data value"}}
        };
        public static readonly TabsModel NoItemList = new() {
            Id = "my-tabs",
            Classes = "app-tabs--custom-modifier"
        };
        public static readonly TabsModel EmptyItemList = new() {
            Items = new List<TabsModel.ItemModel>()
        };
        public static readonly TabsModel IdPrefix = new(
            new TabsModel.ItemModel {
                Label = "Tab 1",
                Panel = "Panel 1 content"
            },
            new TabsModel.ItemModel {
                Label = "Tab 2",
                Panel = "Panel 2 content"
            }
        ) {
            IdPrefix = "custom"
        };
        public static readonly TabsModel HtmlAsText = new(
            new TabsModel.ItemModel("tab-1", "Tab 1", "<p>Panel 1 content</p>"),
            new TabsModel.ItemModel("tab-2", "Tab 2", "<p>Panel 2 content</p>")
        );
        public static readonly TabsModel ItemWithAttributes = new(
            new TabsModel.ItemModel("tab-1", "Tab 1", "Information about tabs") {
                Attributes = new Dictionary<string, string?> {{"data-attribute", "my-attribute"}, {"data-attribute-2", "my-attribute-2"}}
            }
        );
        public static readonly TabsModel PanelWithAttributes = new(
            new TabsModel.ItemModel(
                "tab-1",
                "Tab 1",
                new TabsModel.PanelModel("Panel text") {
                    Attributes = new Dictionary<string, string?> {{"data-attribute", "my-attribute"}, {"data-attribute-2", "my-attribute-2"}}
                }
            )
        );
    }

    private const string PartialName = "GdsTabs";
    public IActionResult Default() => View();
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult Id() => PartialView(PartialName, Examples.Id);
    public IActionResult Title() => PartialView(PartialName, Examples.Title);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult NoItemList() => PartialView(PartialName, Examples.NoItemList);
    public IActionResult EmptyItemList() => PartialView(PartialName, Examples.EmptyItemList);
    public IActionResult IdPrefix() => PartialView(PartialName, Examples.IdPrefix);
    public IActionResult HtmlAsText() => PartialView(PartialName, Examples.HtmlAsText);
    public IActionResult ItemWithAttributes() => PartialView(PartialName, Examples.ItemWithAttributes);
    public IActionResult PanelWithAttributes() => PartialView(PartialName, Examples.PanelWithAttributes);
    public IActionResult Html() => View();
    public IActionResult Axe() => View();
}
