using GdsRazor.Models.Base;

namespace GdsRazor.Models;

public class FileUploadModel : GdsViewModel
{
    public string? Name { get; set; }
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

    public FileUploadModel()
    {
    }

    public FileUploadModel(string id, string name, LabelModel label) : base(id)
    {
        Name = name;
        Label = label;
    }
}
