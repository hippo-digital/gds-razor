using GdsRazor.Models.Base;

namespace GdsRazor.Models;

public class PaginationModel : GdsViewModel
{
    public List<IItemModel>? Items { get; set; }
    public LinkModel? Previous { get; set; }
    public LinkModel? Next { get; set; }
    public string? LandmarkLabel { get; set; }

    public bool BlockLevel => Items == null && (Next != null || Previous != null);

    public interface IItemModel
    {
    }
    
    public class ItemModel : GdsAttributes, IItemModel
    {
        public string? Number { get; set; }
        public string? VisuallyHiddenText { get; set; }
        public string? Href { get; set; }
        public bool Current { get; set; }

        public ItemModel()
        {
        }

        public ItemModel(string href, string number)
        {
            Href = href;
            Number = number;
        }
    }

    public class EllipsisModel : IItemModel
    {
    }


    public class LinkModel : GdsAttributes
    {
        public string? Text { get; set; }
        public string? LabelText { get; set; }
        public string? Href { get; set; }

        public LinkModel()
        {
        }

        public LinkModel(string href)
        {
            Href = href;
        }

        public static implicit operator LinkModel(string s) => new(s);
    }
}
