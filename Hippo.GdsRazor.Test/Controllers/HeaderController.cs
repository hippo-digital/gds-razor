using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class HeaderController : Controller
{
    private static class Examples
    {
        public static readonly HeaderModel Default = new();
        public static readonly HeaderModel Attributes = new() {
            Attributes = new Dictionary<string, string?> {{"data-test-attribute", "value"}, {"data-test-attribute-2", "value-2"}}
        };
        public static readonly HeaderModel Classes = new() {
            Classes = "app-header--custom-modifier"
        };
        public static readonly HeaderModel FullWidth = new() {
            ContainerClasses = "govuk-header__container--full-width",
            NavigationClasses = "govuk-header__navigation--end",
            ProductName = "Product Name"
        };
        public static readonly HeaderModel FullWidthWithNavigation = new() {
            ContainerClasses = "govuk-header__container--full-width",
            NavigationClasses = "govuk-header__navigation--end",
            ProductName = "Product Name",
            Navigation = new List<HeaderModel.ItemModel> {
                new("Navigation item 1") {
                    Href = "#1",
                    Active = true
                },
                ("#2", "Navigation item 2"),
                ("#3", "Navigation item 3")
            }
        };
        public static readonly HeaderModel CustomHomepageUrl = new() {
            HomepageUrl = "/"
        };
        public static readonly HeaderModel WithProductName = new() {
            NavigationClasses = "govuk-header__navigation--end",
            ProductName = "Product Name"
        };
        public static readonly HeaderModel WithServiceName = new() {
            ServiceName = "Service Name",
            ServiceUrl = "/components/header"
        };
        public static readonly HeaderModel WithServiceNameButNoServiceUrl = new() {
            ServiceName = "Service Name"
        };
        public static readonly HeaderModel WithNavigation = new() {
            Navigation = new List<HeaderModel.ItemModel> {
                new("Navigation item 1") {
                    Href = "#1",
                    Active = true
                },
                ("#2", "Navigation item 2"),
                ("#3", "Navigation item 3"),
                ("#4", "Navigation item 4")
            }
        };
        public static readonly HeaderModel WithCustomMenuButtonText = new() {
            MenuButtonText = "Dewislen",
            Navigation = new List<HeaderModel.ItemModel> {
                new("Eitem llywio 1") {
                    Href = "#1",
                    Active = true
                },
                ("#2", "Eitem llywio 2"),
                ("#3", "Eitem llywio 3"),
                ("#4", "Eitem llywio 4")
            }
        };
        public static readonly HeaderModel WithCustomNavigationLabel = new() {
            NavigationLabel = "Custom navigation label",
            Navigation = new List<HeaderModel.ItemModel> {
                new("Navigation item 1") {
                    Href = "#1",
                    Active = true
                },
                ("#2", "Navigation item 2"),
                ("#3", "Navigation item 3"),
                ("#4", "Navigation item 4")
            }
        };
        public static readonly HeaderModel WithCustomNavigationLabelAndCustomMenuButtonText = new() {
            MenuButtonText = "Custom menu button text",
            NavigationLabel = "Custom navigation label",
            Navigation = new List<HeaderModel.ItemModel> {
                new("Navigation item 1") {
                    Href = "#1",
                    Active = true
                },
                ("#2", "Navigation item 2"),
                ("#3", "Navigation item 3"),
                ("#4", "Navigation item 4")
            }
        };
        public static readonly HeaderModel NavigationItemWithHtmlAsText = new() {
            ServiceName = "Service Name",
            ServiceUrl = "/components/header",
            Navigation = new List<HeaderModel.ItemModel> {
                new("<em>Navigation item 1</em>") {
                    Href = "#1",
                    Active = true
                },
                ("#2", "<em>Navigation item 2</em>"),
                ("#3", "<em>Navigation item 3</em>")
            }
        };
        public static readonly HeaderModel NavigationItemWithTextWithoutLink = new() {
            ServiceName = "Service Name",
            ServiceUrl = "/components/header",
            Navigation = new List<HeaderModel.ItemModel> {
                "Navigation item 1",
                "Navigation item 2",
                "Navigation item 3"
            }
        };
        public static readonly HeaderModel NavigationItemWithAttributes = new() {
            Navigation = new List<HeaderModel.ItemModel> {
                new ("Item") {
                    Href = "/link",
                    Attributes = new Dictionary<string, string?> {{"data-attribute", "my-attribute"}, {"data-attribute-2", "my-attribute-2"}}
                }
            }
        };
        public static readonly HeaderModel WithCustomMenuButtonLabel = new() {
            MenuButtonLabel = "Custom button label",
            Navigation = new List<HeaderModel.ItemModel> {
                new("Navigation item 1") {
                    Href = "#1",
                    Active = true
                },
                ("#2", "Navigation item 2"),
                ("#3", "Navigation item 3"),
                ("#4", "Navigation item 4")
            }
        };
    }

    private const string PartialName = "GdsHeader";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult FullWidth() => PartialView(PartialName, Examples.FullWidth);
    public IActionResult FullWidthWithNavigation() => PartialView(PartialName, Examples.FullWidthWithNavigation);
    public IActionResult CustomHomepageUrl() => PartialView(PartialName, Examples.CustomHomepageUrl);
    public IActionResult WithProductName() => PartialView(PartialName, Examples.WithProductName);
    public IActionResult WithServiceName() => PartialView(PartialName, Examples.WithServiceName);
    public IActionResult WithServiceNameButNoServiceUrl() => PartialView(PartialName, Examples.WithServiceNameButNoServiceUrl);
    public IActionResult WithNavigation() => PartialView(PartialName, Examples.WithNavigation);
    public IActionResult WithCustomMenuButtonText() => PartialView(PartialName, Examples.WithCustomMenuButtonText);
    public IActionResult WithCustomNavigationLabel() => PartialView(PartialName, Examples.WithCustomNavigationLabel);
    public IActionResult WithCustomNavigationLabelAndCustomMenuButtonText() => PartialView(PartialName, Examples.WithCustomNavigationLabelAndCustomMenuButtonText);
    public IActionResult NavigationItemWithHtmlAsText() => PartialView(PartialName, Examples.NavigationItemWithHtmlAsText);
    public IActionResult NavigationItemWithTextWithoutLink() => PartialView(PartialName, Examples.NavigationItemWithTextWithoutLink);
    public IActionResult NavigationItemWithAttributes() => PartialView(PartialName, Examples.NavigationItemWithAttributes);
    public IActionResult WithCustomMenuButtonLabel() => PartialView(PartialName, Examples.WithCustomMenuButtonLabel);
    public IActionResult NavigationItemWithHtml() => View();
    public IActionResult NavigationItemWithHtmlWithoutLink() => View();
    public IActionResult Axe() => View(Examples.Default);
    public IActionResult AxeNavigation() => View("Axe", Examples.WithNavigation);
}
