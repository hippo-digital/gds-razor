using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

/// <summary>
/// The footer provides copyright, licensing and other information about your service.
/// </summary>
public class FooterModel : GdsViewModel
{
    /// <summary>
    /// Object containing options for the meta navigation.
    /// </summary>
    public MetaModel? Meta { get; set; }

    /// <summary>
    /// Array of items for use in the navigation section of the footer.
    /// </summary>
    public List<NavigationModel>? Navigation { get; set; }

    /// <summary>
    /// Content to show in the license section of the footer.
    /// If not provided, the text for the Open Government Licence is used.
    /// The content licence is inside a &lt;span&gt; element, so you can only add phrasing content to it.
    /// </summary>
    public GdsContent? ContentLicense { get; set; }

    /// <summary>
    /// Content to show in the copyright notice section of the footer.
    /// If not provided, Crown copyright is used.
    /// The copyright notice is inside an &lt;a&gt; element, so you can only use text formatting elements within it.
    /// </summary>
    public GdsContent? Copyright { get; set; }

    /// <summary>
    /// Classes that can be added to the inner container, useful if you want to make the footer full width.
    /// </summary>
    public string? ContainerClasses { get; set; }

    public bool ShowOglLicenseSvg { get; set; }

    public static string LicenseHref => "https://www.nationalarchives.gov.uk/doc/open-government-licence/version/3/";
    public static string CopyrightHref => "https://www.nationalarchives.gov.uk/information-management/re-using-public-sector-information/uk-government-licensing-framework/crown-copyright/";

    public FooterModel()
    {
        ShowOglLicenseSvg = true;
    }

    public class MetaModel
    {
        /// <summary>
        /// Title for a meta item section.
        /// </summary>
        public string? VisuallyHiddenTitle { get; set; }

        /// <summary>
        /// Content to add to the meta section of the footer, which will appear below any links specified using meta.items.
        /// </summary>
        public GdsContent? Content { get; set; }

        /// <summary>
        /// Array of items for use in the meta section of the footer.
        /// </summary>
        public List<ItemModel>? Items { get; set; }
    }

    public class NavigationModel
    {
        /// <summary>
        /// Title for a section.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Amount of columns to display items in navigation section of the footer.
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// Width of each navigation section in the footer.
        /// </summary>
        public ColumnWidth? Width { get; set; }

        /// <summary>
        /// Array of items to display in the list in navigation section of the footer.
        /// </summary>
        public List<ItemModel>? Items { get; set; }

        public NavigationModel()
        {
        }

        public NavigationModel(string title)
        {
            Title = title;
        }

        public sealed class ColumnWidth
        {
            public static ColumnWidth OneHalf => new ColumnWidth("one-half");
            public static ColumnWidth OneThird => new ColumnWidth("one-third");
            public static ColumnWidth TwoThirds => new ColumnWidth("two-thirds");
            public static ColumnWidth Full => new ColumnWidth("full");

            public string Value { get; }

            private ColumnWidth(string value)
            {
                Value = value;
            }
        }
    }
    
    public class ItemModel : GdsAttributes
    {
        /// <summary>
        /// List item text in the navigation section of the footer.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// List item href attribute in the navigation section of the footer.
        /// Both text and href attributes need to be present to create a link.
        /// </summary>
        public string? Href { get; set; }

        public ItemModel()
        {
        }

        public ItemModel(string href, string text)
        {
            Text = text;
            Href = href;
        }

        public static implicit operator ItemModel((string, string) t) => new(t.Item1, t.Item2);
    }
}
