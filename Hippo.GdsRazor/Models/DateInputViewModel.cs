using Hippo.GdsRazor.Models.Base;

namespace Hippo.GdsRazor.Models;

/// <summary>
/// Use the date input component to help users enter a memorable date or one they can easily look up.
/// </summary>
public class DateInputModel : GdsViewModel
{
    /// <summary>
    /// Optional prefix.
    /// This is used to prefix each item.name using -.
    /// </summary>
    public string? NamePrefix { get; set; }

    /// <summary>
    /// An array of input objects with name, value and classes.
    /// </summary>
    public IEnumerable<ItemModel> Items { get; set; }

    public HintModel? Hint { get; set; }
    public ErrorMessageModel? ErrorMessage { get; set; }

    /// <summary>
    /// Classes to add to the form group (for example to show error state for the whole group).
    /// </summary>
    public string? FormGroupClasses { get; set; }
    public FieldsetModel? Fieldset { get; set; }

    /// <summary>
    /// One or more element IDs to add to the input aria-describedby attribute without a fieldset, used to provide additional descriptive information for screenreader users.
    /// </summary>
    public string? DescribedBy
    {
        get
        {
            var fullText = Fieldset?.DescribedBy ?? "";
            if (ErrorMessage != null) fullText += $" {Id}-error";
            if (Hint != null) fullText += $" {Id}-hint";
            return string.IsNullOrWhiteSpace(fullText) ? null : fullText;
        }
    }

    internal static readonly List<ItemModel> DefaultItems = new()
    {
        new ItemModel("day") { Classes = InputModel.Width.Width2 },
        new ItemModel("month") { Classes = InputModel.Width.Width2 },
        new ItemModel("year") { Classes = InputModel.Width.Width4 }
    };

    public DateInputModel(string id = "date-default") : base(id)
    {
        Items = new List<ItemModel>();
    }

    public class ItemModel : GdsViewModel
    {
        /// <summary>
        /// Item-specific name attribute.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Item-specific label text. If provided, this will be used instead of name for item label text.
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// If provided, it will be used as the initial value of the input.
        /// </summary>
        public string? Value { get; set; }

        public string? Inputmode { get; set; }

        /// <summary>
        /// Attribute to identify input purpose, for instance bday-day.
        /// </summary>
        public string? Autocomplete { get; set; }

        /// <summary>
        /// Attribute to provide a regular expression pattern, used to match allowed character combinations for the input value.
        /// </summary>
        public string? Pattern { get; set; }

        public ItemModel()
        {
        }

        public ItemModel(string name) : this()
        {
            Name = name;
        }
    }
}
