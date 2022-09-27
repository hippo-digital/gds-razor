using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;
using Microsoft.AspNetCore.Html;

namespace Hippo.GdsRazor.Models;

/// <summary>
/// The tabs component lets users navigate between related sections of content, displaying one section at a time.
/// </summary>
public class TabsModel : GdsViewModel
{
    /// <summary>
    /// String to prefix id for each tab item if no id is specified on each item.
    /// </summary>
    public string? IdPrefix { get; set; }

    /// <summary>
    /// Title for the tabs table of contents.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Array of tab items.
    /// </summary>
    public IEnumerable<ItemModel>? Items { get; set; }

    public TabsModel()
    {
    }

    public TabsModel(IEnumerable<ItemModel> items) : this()
    {
        Items = items;
    }

    public TabsModel(params ItemModel[] items) : this(items.ToList())
    {
    }

    public class ItemModel : GdsViewModel
    {
        /// <summary>
        /// The text label of a tab item.
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// Content for the panel.
        /// </summary>
        public PanelModel? Panel { get; set; }

        public ItemModel()
        {
        }

        public ItemModel(string id, string label, PanelModel panel) : base(id)
        {
            Label = label;
            Panel = panel;
        }
    }

    public class PanelModel : GdsWithContent
    {
        public PanelModel()
        {
        }

        public PanelModel(GdsContent content) : base(content)
        {
        }

        public static implicit operator PanelModel(Task<IHtmlContent> t) => new(t);
        public static implicit operator PanelModel(HTML s) => new(s);
        public static implicit operator PanelModel(string s) => new(s);
    }
}
