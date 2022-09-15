using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class LabelModel : GdsWithContent
{
    public string? For { get; set; }
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
