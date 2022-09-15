using GdsRazor.Models.Base;
using GdsRazor.Models.Content;
using Microsoft.AspNetCore.Html;

namespace GdsRazor.Models;

public class HeaderModel : GdsViewModel
{
    public string? HomepageUrl { get; set; }
    public string? AssetsPath { get; set; }
    public string? ProductName { get; set; }
    public string? ServiceName { get; set; }
    public string? ServiceUrl { get; set; }
    public List<ItemModel>? Navigation { get; set; }
    public string? NavigationClasses { get; set; }
    public string? NavigationLabel { get; set; }
    public string? MenuButtonText { get; set; }
    public string? MenuButtonLabel { get; set; }
    public string? ContainerClasses { get; set; }

    public HeaderModel()
    {
        MenuButtonText = "Menu";
    }

    public class ItemModel : GdsAttributes
    {
        public GdsContent? Content { get; set; }
        public string? Href { get; set; }
        public bool Active { get; set; }

        public ItemModel()
        {
        }

        public ItemModel(GdsContent content)
        {
            Content = content;
        }

        public static implicit operator ItemModel(string s) => new(s);
        public static implicit operator ItemModel((string, string) t) => new(t.Item2) { Href = t.Item1 };
    }
}
