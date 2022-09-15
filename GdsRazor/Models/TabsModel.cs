using GdsRazor.Models.Base;
using GdsRazor.Models.Content;
using Microsoft.AspNetCore.Html;

namespace GdsRazor.Models;

public class TabsModel : GdsViewModel
{
    public string? IdPrefix { get; set; }
    public string? Title { get; set; }
    public List<ItemModel>? Items { get; set; }

    public TabsModel()
    {
    }

    public TabsModel(List<ItemModel> items) : this()
    {
        Items = items;
    }

    public TabsModel(params ItemModel[] items) : this(items.ToList())
    {
    }

    public class ItemModel : GdsViewModel
    {
        public string? Label { get; set; }
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
    }
}
