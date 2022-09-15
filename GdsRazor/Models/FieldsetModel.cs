using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class FieldsetModel : GdsWithContent
{
    public string? DescribedBy { get; set; }
    public LegendModel? Legend { get; set; }
    public string? Role { get; set; }

    public class LegendModel : GdsWithContent
    {
        public bool IsPageHeading { get; set; }

        public LegendModel()
        {
        }

        public LegendModel(GdsContent content) : base(content)
        {
        }

        public static class Sizes
        {
            public const string Small = "govuk-fieldset__legend--s";
            public const string Medium = "govuk-fieldset__legend--m";
            public const string Large = "govuk-fieldset__legend--l";
        }

        public static implicit operator LegendModel(string s) => new(s);
    }
}
