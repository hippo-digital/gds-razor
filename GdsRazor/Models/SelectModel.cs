using GdsRazor.Models.Base;

namespace GdsRazor.Models;

public class SelectModel : GdsViewModel
{
    public string? Name { get; set; }
    public List<ItemModel>? Items { get; set; }
    public string? Value { get; set; }
    private string? _describedBy;
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
        public string? Value { get; set; }
        public string? Text { get; set; }
        public bool Selected { get; set; }
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
