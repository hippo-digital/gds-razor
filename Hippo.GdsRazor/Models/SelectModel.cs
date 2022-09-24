using Hippo.GdsRazor.Models.Base;

namespace Hippo.GdsRazor.Models;

public class SelectModel : GdsViewModel
{
    /// <summary>
    /// Name property for the select.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Array of option items for the select.
    /// </summary>
    public List<ItemModel>? Items { get; set; }

    /// <summary>
    /// Value for the option which should be selected.
    /// Use this as an alternative to setting the selected option on each individual item.
    /// </summary>
    public string? Value { get; set; }

    private string? _describedBy;
    /// <summary>
    /// One or more element IDs to add to the input aria-describedby attribute without a fieldset, used to provide additional descriptive information for screenreader users.
    /// </summary>
    public string? DescribedBy
    {
        get
        {
            var fullText = _describedBy ?? "";
            if (ErrorMessage != null) fullText += $" {Id}-error";
            if (Hint != null) fullText += $" {Id}-hint";
            return string.IsNullOrWhiteSpace(fullText) ? null : fullText;
        }
        set => _describedBy = value;
    }

    public LabelModel? Label { get; set; }
    public HintModel? Hint { get; set; }
    public ErrorMessageModel? ErrorMessage { get; set; }

    /// <summary>
    /// Classes to add to the form group (for example to show error state for the whole group).
    /// </summary>
    public string? FormGroupClasses { get; set; }

    public SelectModel()
    {
    }

    public SelectModel(string id, string name, List<ItemModel> items) : base(id)
    {
        Name = name;
        Items = items;
    }

    public SelectModel(string id, string name, params ItemModel[] items) : this(id, name, items.ToList())
    {
    }

    public class ItemModel : GdsAttributes
    {
        /// <summary>
        /// Value for the option item.
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// Text for the option item.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Whether the option should be selected when the page loads. Takes precedence over the top-level value option.
        /// </summary>
        public bool? Selected { get; set; }

        /// <summary>
        /// Sets the option item as disabled.
        /// </summary>
        public bool Disabled { get; set; }

        public ItemModel()
        {
        }

        public ItemModel(string text)
        {
            Text = text;
        }

        public static implicit operator ItemModel(string s) => new(s);
    }
}
