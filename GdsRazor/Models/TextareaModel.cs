using GdsRazor.Models.Base;

namespace GdsRazor.Models;

public class TextareaModel : GdsViewModel
{
    /// <summary>
    /// The name of the textarea, which is submitted with the form data.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Optional field to enable or disable the spellcheck attribute on the textarea.
    /// </summary>
    public bool? Spellcheck { get; set; }

    /// <summary>
    /// Optional number of textarea rows.
    /// </summary>
    public int? Rows { get; set; }

    /// <summary>
    /// Optional initial value of the textarea.
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

    /// <summary>
    /// Attribute to identify input purpose, for example postal-code or username.
    /// </summary>
    public string? Autocomplete { get; set; }

    public TextareaModel()
    {
    }

    public TextareaModel(string id, string name, LabelModel label) : base(id)
    {
        Name = name;
        Label = label;
    }
}
