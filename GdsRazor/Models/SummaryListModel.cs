using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

/// <summary>
/// Use the summary list to summarise information, for example, a user’s responses at the end of a form.
/// </summary>
public class SummaryListModel : GdsViewModel
{
    public const string NoBorder = "govuk-summary-list--no-border";

    /// <summary>
    /// Array of row item objects.
    /// </summary>
    public List<RowModel>? Rows { get; set; }

    public SummaryListModel()
    {
    }

    public SummaryListModel(List<RowModel> rows) : this()
    {
        Rows = rows;
    }

    public SummaryListModel(params RowModel[] rows) : this(rows.ToList())
    {
    }

    public class RowModel : GdsViewModel
    {
        public ItemModel? Key { get; set; }
        public ItemModel? Value { get; set; }

        /// <summary>
        /// Classes to add to the actions wrapper.
        /// </summary>
        public string? ActionsClasses { get; set; }

        /// <summary>
        /// Array of action item objects.
        /// </summary>
        public List<ActionModel>? Actions { get; set; }

        public RowModel()
        {
        }

        public RowModel(ItemModel key, ItemModel value) : this()
        {
            Key = key;
            Value = value;
        }
    }

    public class ActionModel : LinkModel
    {
        public ActionModel()
        {
        }

        public ActionModel(string href, GdsContent content) : base(content)
        {
            Href = href;
        }

        public static implicit operator ActionModel((string, string) t) => new(t.Item1, t.Item2);
    }

    public class ItemModel : GdsWithContent
    {
        public static implicit operator ItemModel(string s) => new() { Content = s };
        public static implicit operator ItemModel(HTML h) => new() { Content = h };
    }
}
