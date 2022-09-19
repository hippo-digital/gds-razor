namespace GdsRazor.Models;

/// <summary>
/// Help users know how much text they can enter when there is a limit on the number of characters.
/// </summary>
public class CharacterCountModel : TextareaModel
{
    /// <summary>
    /// The maximum number of characters.
    /// If <c>MaxWords</c> is provided, the <c>MaxLength</c> option will be ignored.
    /// </summary>
    public int? MaxLength { get; set; }

    /// <summary>
    /// The maximum number of words.
    /// If <c>MaxWords</c> is provided, the <c>MaxLength</c> option will be ignored.
    /// </summary>
    public int? MaxWords { get; set; }

    /// <summary>
    /// The percentage value of the limit at which point the count message is displayed.
    /// If this attribute is set, the count message will be hidden by default.
    /// </summary>
    public int? Threshold { get; set; }

    /// <summary>
    /// Classes to add to the count message.
    /// </summary>
    public string? CountMessageClasses { get; set; }

    public string? FallbackHintText { get; set; }

    public CharacterCountModel()
    {
    }

    public CharacterCountModel(string id, string name, LabelModel label) : base(id, name, label)
    {
    }
}
