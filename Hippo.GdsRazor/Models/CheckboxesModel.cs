using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

/// <summary>
/// Let users select one or more options by using the checkboxes component.
/// </summary>
public class CheckboxesModel : GdsViewModel
{
    private string? _describedBy;
    /// <summary>
    /// One or more element IDs to add to the input aria-describedby attribute without a fieldset, used to provide additional descriptive information for screenreader users.
    /// </summary>
    public string? DescribedBy
    {
        get
        {
            var fullText = Fieldset?.DescribedBy ?? _describedBy ?? "";
            if (ErrorMessage != null) fullText += $" {IdPrefix}-error";
            if (Hint != null) fullText += $" {IdPrefix}-hint";
            return string.IsNullOrWhiteSpace(fullText) ? null : fullText;
        }
        set => _describedBy = value;
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
    /// String to prefix id for each checkbox item if no id is specified on each item.
    /// If not passed, fall back to using the name option instead.
    /// </summary>
    public string? IdPrefix
    {
        get => _idPrefix ?? Name;
        set => _idPrefix = value;
    }

    /// <summary>
    /// Name attribute for all checkbox items.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Array of checkbox items objects.
    /// </summary>
    public IEnumerable<IItemModel>? Items { get; set; }

    /// <summary>
    /// Array of values for checkboxes which should be checked when the page loads.
    /// Use this as an alternative to setting the checked option on each individual item.
    /// </summary>
    public List<string>? Values { get; set; }

    public CheckboxesModel()
    {
    }

    public CheckboxesModel(string name, IEnumerable<IItemModel> items) : this()
    {
        Name = name;
        Items = items;
    }

    public CheckboxesModel(string name, params IItemModel[] items) : this(name, items.ToList())
    {
    }

    public interface IItemModel
    {
    }

    public class ItemModel : GdsWithContent, IItemModel
    {
        /// <summary>
        /// Specific name for the checkbox item.
        /// If omitted, then component global name string will be applied.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Value for the checkbox input.
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// Provide attributes and classes to each checkbox item label.
        /// </summary>
        public LabelModel? Label { get; set; }

        /// <summary>
        /// Provide hint to each checkbox item.
        /// </summary>
        public HintModel? Hint { get; set; }

        /// <summary>
        /// Whether the checkbox should be checked when the page loads.
        /// Takes precedence over the top-level values option.
        /// </summary>
        public bool? Checked { get; set; }

        /// <summary>
        /// Content provided will be revealed when the item is checked.
        /// </summary>
        public GdsContent? ConditionalContent { get; set; }

        /// <summary>
        /// If set to exclusive, implements a 'None of these' type behaviour via JavaScript when checkboxes are clicked.
        /// </summary>
        public string? Behaviour { get; set; }

        /// <summary>
        /// If true, checkbox will be disabled.
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
        public string? Divider { get; set; }

        public DividerModel()
        {
        }

        public DividerModel(string divider)
        {
            Divider = divider;
        }
    }
}
