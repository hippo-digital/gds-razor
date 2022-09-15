using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class CheckboxesModel : GdsViewModel
{
    private string? _describedBy;
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
    public string? FormGroupClasses { get; set; }
    private string? _idPrefix;
    public string? IdPrefix
    {
        get => _idPrefix ?? Name;
        set => _idPrefix = value;
    }
    public string? Name { get; set; }
    public List<IItemModel>? Items { get; set; }
    public List<bool>? Values { get; set; }

    public CheckboxesModel()
    {
    }

    public CheckboxesModel(string name, List<IItemModel> items) : this()
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
        public string? Name { get; set; }
        public string? Value { get; set; }
        public LabelModel? Label { get; set; }
        public HintModel? Hint { get; set; }
        public bool Checked { get; set; }
        public GdsContent? ConditionalContent { get; set; }
        public string? Behaviour { get; set; }
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
    }
}
