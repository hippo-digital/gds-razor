using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class InputModel : GdsViewModel
{
    /// <summary>
    /// The name of the input, which is submitted with the form data.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Type of input control to render, for example, a password input control.
    /// </summary>
    public string? Type { get; set; }

    public string? Inputmode { get; set; }

    /// <summary>
    /// Optional initial value of the input.
    /// </summary>
    public string? Value { get; set; }

    private string? _describedBy;
    /// <summary>
    /// One or more element IDs to add to the aria-describedby attribute, used to provide additional descriptive information for screenreader users.
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
    public AffixModel? Prefix { get; set; }
    public AffixModel? Suffix { get; set; }

    /// <summary>
    /// Classes to add to the form group (for example to show error state for the whole group).
    /// </summary>
    public string? FormGroupClasses { get; set; }

    /// <summary>
    /// Attribute to identify input purpose, for instance "postal-code" or "username".
    /// </summary>
    public string? Autocomplete { get; set; }

    /// <summary>
    /// Attribute to provide a regular expression pattern, used to match allowed character combinations for the input value.
    /// </summary>
    public string? Pattern { get; set; }

    /// <summary>
    /// Optional field to enable or disable the spellcheck attribute on the input.
    /// </summary>
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
