using GdsRazor.Models.Base;

namespace GdsRazor.Models;

/// <summary>
/// Help users navigate forwards and backwards through a series of pages.
/// For example, search results or guidance that’s divided into multiple website pages.
/// </summary>
public class PaginationModel : GdsViewModel
{
    /// <summary>
    /// The array of link objects.
    /// </summary>
    public List<IItemModel>? Items { get; set; }

    /// <summary>
    /// A link to the previous page, if there is a previous page.
    /// </summary>
    public LinkModel? Previous { get; set; }

    /// <summary>
    /// A link to the next page, if there is a next page.
    /// </summary>
    public LinkModel? Next { get; set; }

    /// <summary>
    /// The label for the navigation landmark that wraps the pagination.
    /// </summary>
    public string? LandmarkLabel { get; set; }

    public bool BlockLevel => Items == null && (Next != null || Previous != null);

    public interface IItemModel
    {
    }
    
    public class ItemModel : GdsAttributes, IItemModel
    {
        /// <summary>
        /// The pagination item text - usually a page number.
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// A visually hidden prefix used before the error message.
        /// </summary>
        public string? VisuallyHiddenText { get; set; }

        /// <summary>
        /// The link's URL.
        /// </summary>
        public string? Href { get; set; }

        /// <summary>
        /// Set to true to indicate the current page the user is on.
        /// </summary>
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
        /// <summary>
        /// The link text.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// The optional label that goes underneath the link, providing further context for the user about where the link goes.
        /// </summary>
        public string? LabelText { get; set; }

        /// <summary>
        /// The other page's URL.
        /// </summary>
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
