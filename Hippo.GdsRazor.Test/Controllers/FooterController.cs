using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class FooterController : Controller
{
    private static class Examples
    {
        public static readonly FooterModel Default = new();
        public static readonly FooterModel Attributes = new() {
            Attributes = new Dictionary<string, string?> {{"data-test-attribute", "value"}, {"data-test-attribute-2", "value-2"}}
        };
        public static readonly FooterModel Classes = new() {
            Classes = "app-footer--custom-modifier"
        };
        public static readonly FooterModel WithContainerClasses = new() {
            ContainerClasses = "app-width-container"
        };
        public static readonly FooterModel WithHtmlPassedAsTextContent = new() {
            ContentLicense = "Mae'r holl gynnwys ar gael dan <a class=\"govuk-footer__link\" " +
                             "href=\"https://www.nationalarchives.gov.uk/doc/open-government-licence-cymraeg/version/3/\" " +
                             "rel=\"license\">Drwydded y Llywodraeth Agored v3.0</a>, ac eithrio lle nodir yn wahanol",
            Copyright = "<span>Hawlfraint y Goron</span>"
        };
        public static readonly FooterModel WithEmptyMeta = new() {
            Meta = new FooterModel.MetaModel()
        };
        public static readonly FooterModel WithEmptyMetaItems = new() {
            Meta = new FooterModel.MetaModel {
                Items = new List<FooterModel.ItemModel>()
            }
        };
        public static readonly FooterModel MetaHtmlAsText = new() {
            Meta = new FooterModel.MetaModel {
                Content = "GOV.UK Prototype Kit <strong>v7.0.1</strong>"
            }
        };
        public static readonly FooterModel WithMeta = new() {
            Meta = new FooterModel.MetaModel {
                VisuallyHiddenTitle = "Items",
                Items = new List<FooterModel.ItemModel> {
                    ("#1", "Item 1"),
                    ("#2", "Item 2"),
                    ("#3", "Item 3")
                }
            }
        };
        public static readonly FooterModel WithCustomMeta = new() {
            Meta = new FooterModel.MetaModel {
                Content = "GOV.UK Prototype Kit v7.0.1"
            }
        };
        public static readonly FooterModel WithMetaItemAttributes = new() {
            Meta = new FooterModel.MetaModel {
                Items = new List<FooterModel.ItemModel> {
                    new("#1", "meta item 1") {
                        Attributes = new Dictionary<string, string?> {{"data-attribute", "my-attribute"}, {"data-attribute-2", "my-attribute-2"}}
                    }
                }
            }
        };
        public static readonly FooterModel WithNavigation = new() {
            Navigation = new List<FooterModel.NavigationModel> {
                new("Two column list") {
                    Width = FooterModel.NavigationModel.ColumnWidth.TwoThirds,
                    Columns = 2,
                    Items = new List<FooterModel.ItemModel> {
                        ("#1", "Navigation item 1"),
                        ("#2", "Navigation item 2"),
                        ("#3", "Navigation item 3"),
                        ("#4", "Navigation item 4"),
                        ("#5", "Navigation item 5"),
                        ("#6", "Navigation item 6"),
                    }
                },
                new("Single column list") {
                    Width = FooterModel.NavigationModel.ColumnWidth.OneThird,
                    Columns = 2,
                    Items = new List<FooterModel.ItemModel> {
                        ("#1", "Navigation item 1"),
                        ("#2", "Navigation item 2"),
                        ("#3", "Navigation item 3")
                    }
                }
            }
        };
        public static readonly FooterModel WithEmptyNavigation = new() {
            Navigation = null
        };
        public static readonly FooterModel WithNavigationItemAttributes = new() {
            Navigation = new List<FooterModel.NavigationModel> {
                new("Single column list 1") {
                    Items = new List<FooterModel.ItemModel> {
                        new("#1", "Navigation item 1") {
                            Attributes = new Dictionary<string, string?> {{"data-attribute", "my-attribute"}, {"data-attribute-2", "my-attribute-2"}}
                        }
                    }
                }
            },
        };
        public static readonly FooterModel WithDefaultWidthNavigationOneColumn = new() {
            Navigation = new List<FooterModel.NavigationModel> {
                new("Navigation section") {
                    Items = new List<FooterModel.ItemModel> {
                        ("#1", "Navigation item 1"),
                        ("#2", "Navigation item 2"),
                        ("#3", "Navigation item 3"),
                        ("#4", "Navigation item 4"),
                        ("#5", "Navigation item 5"),
                        ("#6", "Navigation item 6"),
                    }
                }
            }
        };
        public static readonly FooterModel WithDefaultWidthNavigationTwoColumns = new() {
            Navigation = new List<FooterModel.NavigationModel> {
                new("Navigation section") {
                    Columns = 2,
                    Items = new List<FooterModel.ItemModel> {
                        ("#1", "Navigation item 1"),
                        ("#2", "Navigation item 2"),
                        ("#3", "Navigation item 3"),
                        ("#4", "Navigation item 4"),
                        ("#5", "Navigation item 5"),
                        ("#6", "Navigation item 6"),
                    }
                }
            }
        };
        public static readonly FooterModel WithCustomTextContentLicenceAndCopyrightNotice = new() {
            ContentLicense = "Mae'r holl gynnwys ar gael dan Drwydded y Llywodraeth Agored v3.0, ac eithrio lle nodir yn wahanol",
            Copyright = "© Hawlfraint y Goron"
        };
    }

    private const string PartialName = "GdsFooter";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult WithContainerClasses() => PartialView(PartialName, Examples.WithContainerClasses);
    public IActionResult WithHtmlPassedAsTextContent() => PartialView(PartialName, Examples.WithHtmlPassedAsTextContent);
    public IActionResult WithEmptyMeta() => PartialView(PartialName, Examples.WithEmptyMeta);
    public IActionResult WithEmptyMetaItems() => PartialView(PartialName, Examples.WithEmptyMetaItems);
    public IActionResult MetaHtmlAsText() => PartialView(PartialName, Examples.MetaHtmlAsText);
    public IActionResult WithMeta() => PartialView(PartialName, Examples.WithMeta);
    public IActionResult WithCustomMeta() => PartialView(PartialName, Examples.WithCustomMeta);
    public IActionResult WithMetaItemAttributes() => PartialView(PartialName, Examples.WithMetaItemAttributes);
    public IActionResult WithNavigation() => PartialView(PartialName, Examples.WithNavigation);
    public IActionResult WithEmptyNavigation() => PartialView(PartialName, Examples.WithEmptyNavigation);
    public IActionResult WithNavigationItemAttributes() => PartialView(PartialName, Examples.WithNavigationItemAttributes);
    public IActionResult WithDefaultWidthNavigationOneColumn() => PartialView(PartialName, Examples.WithDefaultWidthNavigationOneColumn);
    public IActionResult WithDefaultWidthNavigationTwoColumns() => PartialView(PartialName, Examples.WithDefaultWidthNavigationTwoColumns);
    public IActionResult WithCustomTextContentLicenceAndCopyrightNotice() => PartialView(PartialName, Examples.WithCustomTextContentLicenceAndCopyrightNotice);
    public IActionResult WithCustomHtmlContentLicenceAndCopyrightNotice() => View();
    public IActionResult WithMetaHtml() => View();
    public IActionResult Axe() => View(Examples.Default);
    public IActionResult AxeMeta() => View("Axe", Examples.WithMeta);
    public IActionResult AxeNavigation() => View("Axe", Examples.WithNavigation);
}
