using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class PaginationController : Controller
{
    private static class Examples
    {
        public static readonly PaginationModel Default = new() {
            Previous = "/previous",
            Next = "/next",
            Items = new List<PaginationModel.IItemModel> {
                new PaginationModel.ItemModel("/page/1", "1"),
                new PaginationModel.ItemModel("/page/2", "2") { Current = true },
                new PaginationModel.ItemModel("/page/3", "3")
            }
        };
        public static readonly PaginationModel WithManyPages = new() {
            Previous = "/previous",
            Next = "/next",
            Items = new List<PaginationModel.IItemModel> {
                new PaginationModel.ItemModel("/page/1", "1"),
                new PaginationModel.EllipsisModel(),
                new PaginationModel.ItemModel("/page/8", "8"),
                new PaginationModel.ItemModel("/page/9", "9"),
                new PaginationModel.ItemModel("/page/10", "10") { Current = true },
                new PaginationModel.ItemModel("/page/11", "11"),
                new PaginationModel.ItemModel("/page/12", "12"),
                new PaginationModel.EllipsisModel(),
                new PaginationModel.ItemModel("/page/40", "40")
            }
        };
        public static readonly PaginationModel WithCustomNavigationLandmark = new() {
            Previous = "/previous",
            Next = "/next",
            LandmarkLabel = "search",
            Items = new List<PaginationModel.IItemModel> {
                new PaginationModel.ItemModel("/page/1", "1"),
                new PaginationModel.ItemModel("/page/2", "2") { Current = true },
                new PaginationModel.ItemModel("/page/3", "3")
            }
        };
        public static readonly PaginationModel WithCustomLinkAndItemText = new() {
            Previous = new PaginationModel.LinkModel("/previous") { Text = "Previous page" },
            Next = new PaginationModel.LinkModel("/next") { Text = "Next page" },
            Items = new List<PaginationModel.IItemModel> {
                new PaginationModel.ItemModel("/page/1", "one"),
                new PaginationModel.ItemModel("/page/2", "two") { Current = true },
                new PaginationModel.ItemModel("/page/3", "three")
            }
        };
        public static readonly PaginationModel WithCustomAccessibleLabelsOnItemLinks = new() {
            Previous = "/previous",
            Next = "/next",
            Items = new List<PaginationModel.IItemModel> {
                new PaginationModel.ItemModel("/page/1", "1") { VisuallyHiddenText = "1st page" },
                new PaginationModel.ItemModel("/page/2", "2") { VisuallyHiddenText = "2nd page (you are currently on this page)", Current = true },
                new PaginationModel.ItemModel("/page/3", "3") { VisuallyHiddenText = "3rd page" }
            }
        };
        public static readonly PaginationModel WithPreviousAndNextOnly = new() {
            Previous = "/previous",
            Next = "/next"
        };
        public static readonly PaginationModel WithPreviousAndNextOnlyAndLabels = new() {
            Previous = new PaginationModel.LinkModel("/previous") { Text = "Previous page", LabelText = "1 of 3" },
            Next = new PaginationModel.LinkModel("/next") { Text = "Next page", LabelText = "3 of 3" }
        };
    }

    private const string PartialName = "GdsPagination";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult WithManyPages() => PartialView(PartialName, Examples.WithManyPages);
    public IActionResult WithCustomNavigationLandmark() => PartialView(PartialName, Examples.WithCustomNavigationLandmark);
    public IActionResult WithCustomLinkAndItemText() => PartialView(PartialName, Examples.WithCustomLinkAndItemText);
    public IActionResult WithCustomAccessibleLabelsOnItemLinks() => PartialView(PartialName, Examples.WithCustomAccessibleLabelsOnItemLinks);
    public IActionResult WithPreviousAndNextOnly() => PartialView(PartialName, Examples.WithPreviousAndNextOnly);
    public IActionResult WithPreviousAndNextOnlyAndLabels() => PartialView(PartialName, Examples.WithPreviousAndNextOnlyAndLabels);
    public IActionResult Axe() => View(Examples.Default);
}
