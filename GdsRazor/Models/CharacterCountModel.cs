namespace GdsRazor.Models;

public class CharacterCountModel : TextareaModel
{
    public int? MaxLength { get; set; }
    public int? MaxWords { get; set; }
    public int? Threshold { get; set; }
    public string? CountMessageClasses { get; set; }
    public string? FallbackHintText { get; set; }

    public CharacterCountModel()
    {
    }

    public CharacterCountModel(string id, string name, LabelModel label) : base(id, name, label)
    {
    }
}
