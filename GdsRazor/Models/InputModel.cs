using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class InputModel : GdsViewModel
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Inputmode { get; set; }
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
    public AffixModel? Prefix { get; set; }
    public AffixModel? Suffix { get; set; }
    public string? FormGroupClasses { get; set; }
    public string? Autocomplete { get; set; }
    public string? Pattern { get; set; }
    public bool Spellcheck { get; set; }

    public InputModel()
    {
    }

    public InputModel(string id, string name, LabelModel label) : base(id)
    {
        Name = name;
        Label = label;
    }

    public class AffixModel : GdsWithContent
    {
        public AffixModel()
        {
        }

        public AffixModel(GdsContent content) : base(content)
        {
        }

        public static implicit operator AffixModel(string s) => new(s);
    }

    public static class Width
    {
        public const string Width30 = "govuk-input--width-30";
        public const string Width20 = "govuk-input--width-20";
        public const string Width10 = "govuk-input--width-10";
        public const string Width5 = "govuk-input--width-5";
        public const string Width4 = "govuk-input--width-4";
        public const string Width3 = "govuk-input--width-3";
        public const string Width2 = "govuk-input--width-2";
        
    }
}
