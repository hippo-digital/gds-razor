using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class RadiosModel : GdsViewModel
{
    /// <summary>
    /// One or more element IDs to add to the input aria-describedby attribute without a fieldset, used to provide additional descriptive information for screenreader users.
    /// </summary>
    public string? DescribedBy
    {
        get
        {
            var fullText = Fieldset?.DescribedBy ?? "";
            if (ErrorMessage != null) fullText += $" {IdPrefix}-error";
            if (Hint != null) fullText += $" {IdPrefix}-hint";
            return string.IsNullOrWhiteSpace(fullText) ? null : fullText;
        }
    }

    public FieldsetModel? Fieldset { get; set; }
    public HintModel? Hint { get; set; }
    public ErrorMessageModel? ErrorMessage { get; set; }

    /// <summary>
    /// Classes to add to the form group (for example to show error state for the whole group).
    /// </summary>
    public string? FormGroupClasses { get; set; }

    private string? _idPrefix;
    /// <summary>
    /// String to prefix ID for each radio item if no ID is specified on each item.
    /// If idPrefix is not passed, fallback to using the name attribute instead.
    /// </summary>
    public string? IdPrefix
    {
        get => _idPrefix ?? Name;
        set => _idPrefix = value;
    }

    /// <summary>
    /// Name attribute for each radio item.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Array of radio items objects.
    /// </summary>
    public List<IItemModel>? Items { get; set; }

    /// <summary>
    /// The value for the radio which should be checked when the page loads.
    /// Use this as an alternative to setting the checked option on each individual item.
    /// </summary>
    public string? Value { get; set; }

    public RadiosModel()
    {
    }

    public RadiosModel(string name, List<IItemModel> items)
    {
        Name = name;
        Items = items;
    }

    public RadiosModel(string name, params IItemModel[] items) : this(name, items.ToList())
    {
    }
    
    public interface IItemModel
    {
    }
    
    public class ItemModel : GdsWithContent, IItemModel
    {
        /// <summary>
        /// Value for the radio input.
        /// </summary>
        public string? Value { get; set; }

        public LabelModel? Label { get; set; }
        public HintModel? Hint { get; set; }

        /// <summary>
        /// Whether the radio should be checked when the page loads. Takes precedence over the top-level value option.
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// Content provided will be revealed when the item is checked.
        /// </summary>
        public GdsContent? ConditionalContent { get; set; }

        /// <summary>
        /// If true, radio will be disabled.
        /// </summary>
        public bool Disabled { get; set; }

        public ItemModel()
        {
        }

        public ItemModel(string value, GdsContent content) : base(content)
        {
            Value = value;
        }
    }

    public class DividerModel : IItemModel
    {
        /// <summary>
        /// Divider text to separate radio items, for example the text 'or'.
        /// </summary>
        public string? Divider { get; set; }
    }
}
