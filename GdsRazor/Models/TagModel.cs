using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

/// <summary>
/// Use the tag component to show users the status of something.
/// </summary>
public class TagModel : GdsWithContent
{
    public TagModel()
    {
    }

    public TagModel(GdsContent content) : base(content)
    {
    }
    
    public static class Colors
    {
        public const string Grey = "govuk-tag--grey";
        public const string Purple = "govuk-tag--purple";
        public const string Turquoise = "govuk-tag--turquoise";
        public const string Blue = "govuk-tag--blue";
        public const string Yellow = "govuk-tag--yellow";
        public const string Orange = "govuk-tag--orange";
        public const string Red = "govuk-tag--red";
        public const string Pink = "govuk-tag--pink";
        public const string Green = "govuk-tag--green";
    }

    public static implicit operator TagModel(string s) => new(s);
}
