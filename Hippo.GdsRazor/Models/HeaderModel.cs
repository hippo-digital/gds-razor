using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

/// <summary>
/// The GOV.UK header shows users that they are on GOV.UK and which service they are using.
/// </summary>
public class HeaderModel : GdsViewModel
{
    /// <summary>
    /// The URL of the homepage.
    /// </summary>
    public string? HomepageUrl { get; set; }

    /// <summary>
    /// The public path for the assets folder.
    /// </summary>
    public string? AssetsPath { get; set; }

    /// <summary>
    /// Product name, used when the product name follows on directly from 'GOV.UK'.
    /// For example, GOV.UK Pay or GOV.UK Design System.
    /// In most circumstances, you should use serviceName.
    /// </summary>
    public string? ProductName { get; set; }

    /// <summary>
    /// The name of your service, included in the header.
    /// </summary>
    public string? ServiceName { get; set; }

    /// <summary>
    /// URL for the service name anchor.
    /// </summary>
    public string? ServiceUrl { get; set; }

    /// <summary>
    /// An array of navigation item objects.
    /// </summary>
    public IEnumerable<ItemModel>? Navigation { get; set; }

    /// <summary>
    /// Classes for the navigation section of the header.
    /// </summary>
    public string? NavigationClasses { get; set; }

    /// <summary>
    /// Text for the aria-label attribute of the navigation.
    /// </summary>
    public string? NavigationLabel { get; set; }

    /// <summary>
    /// Text for the button that toggles the navigation.
    /// </summary>
    public string? MenuButtonText { get; set; }

    /// <summary>
    /// Text for the aria-label attribute of the button that toggles the navigation.
    /// </summary>
    public string? MenuButtonLabel { get; set; }

    /// <summary>
    /// Classes for the container, useful if you want to make the header fixed width.
    /// </summary>
    public string? ContainerClasses { get; set; }

    public HeaderModel()
    {
        MenuButtonText = "Menu";
    }

    public class ItemModel : GdsAttributes
    {
        /// <summary>
        /// Content for the navigation item.
        /// </summary>
        public GdsContent? Content { get; set; }

        /// <summary>
        /// URL of the navigation item anchor.
        /// </summary>
        public string? Href { get; set; }

        /// <summary>
        /// Flag to mark the navigation item as active or not.
        /// </summary>
        public bool Active { get; set; }

        public ItemModel()
        {
        }

        public ItemModel(GdsContent content)
        {
            Content = content;
        }

        public static implicit operator ItemModel(string s) => new(s);
        public static implicit operator ItemModel(HTML s) => new(s);
        public static implicit operator ItemModel((string, string) t) => new(t.Item2) { Href = t.Item1 };
        public static implicit operator ItemModel((string, HTML) t) => new(t.Item2) { Href = t.Item1 };
    }
}
