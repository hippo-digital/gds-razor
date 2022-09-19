using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class LabelModel : GdsWithContent
{
    /// <summary>
    /// The value of the for attribute, the ID of the input the label is associated with.
    /// </summary>
    public string? For { get; set; }

    /// <summary>
    /// Whether the label also acts as the heading for the page.
    /// </summary>
    public bool IsPageHeading { get; set; }

    public LabelModel()
    {
    }

    public LabelModel(GdsContent content) : base(content)
    {
    }

    public static implicit operator LabelModel(string s) => new(s);

    public static class Size
    {
        public const string Small = "govuk-label--s";
        public const string Medium = "govuk-label--m";
        public const string Large = "govuk-label--l";
    }
}
