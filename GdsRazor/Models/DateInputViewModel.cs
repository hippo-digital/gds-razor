using GdsRazor.Models.Base;

namespace GdsRazor.Models;

public class DateInputModel : GdsViewModel
{
    public string? NamePrefix { get; set; }
    public List<ItemModel> Items { get; set; }
    public HintModel? Hint { get; set; }
    public ErrorMessageModel? ErrorMessage { get; set; }
    public string? FormGroupClasses { get; set; }
    public FieldsetModel? Fieldset { get; set; }
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

    private static readonly List<ItemModel> DefaultItems = new()
    {
        new ItemModel("day") { Classes = InputModel.Width.Width2 },
        new ItemModel("month") { Classes = InputModel.Width.Width2 },
        new ItemModel("year") { Classes = InputModel.Width.Width4 }
    };

    public DateInputModel(string id = "date-default") : base(id)
    {
        Items = DefaultItems;
    }

    public class ItemModel : GdsViewModel
    {
        public string? Name { get; set; }
        public string? Label { get; set; }
        public string? Value { get; set; }
        public string? Inputmode { get; set; }
        public string? Autocomplete { get; set; }
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
