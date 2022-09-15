using GdsRazor.Models.Base;
using GdsRazor.Models.Content;
using Microsoft.AspNetCore.Html;

namespace GdsRazor.Models;

public class FooterModel : GdsViewModel
{
    public MetaModel? Meta { get; set; }
    public List<NavigationModel>? Navigation { get; set; }
    public GdsContent? ContentLicense { get; set; }
    public GdsContent? Copyright { get; set; }
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
        public string? VisuallyHiddenTitle { get; set; }
        public GdsContent? Content { get; set; }
        public List<ItemModel>? Items { get; set; }
    }

    public class NavigationModel
    {
        public string? Title { get; set; }
        public int Columns { get; set; }
        public ColumnWidth? Width { get; set; }
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
        public string? Text { get; set; }
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
