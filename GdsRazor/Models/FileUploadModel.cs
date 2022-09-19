using GdsRazor.Models.Base;

namespace GdsRazor.Models;

/// <summary>
/// Help users select and upload a file.
/// </summary>
public class FileUploadModel : GdsViewModel
{
    /// <summary>
    /// The name of the input, which is submitted with the form data.
    /// </summary>
    public string? Name { get; set; }

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

    /// <summary>
    /// Classes to add to the form group (for example to show error state for the whole group).
    /// </summary>
    public string? FormGroupClasses { get; set; }

    public FileUploadModel()
    {
    }

    public FileUploadModel(string id, string name, LabelModel label) : base(id)
    {
        Name = name;
        Label = label;
    }
}
