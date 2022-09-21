using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

/// <summary>
/// Use the fieldset component to group related form inputs.
/// </summary>
public class FieldsetModel : GdsWithContent
{
    /// <summary>
    /// One or more element IDs to add to the aria-describedby attribute, used to provide additional descriptive information for screenreader users.
    /// </summary>
    public string? DescribedBy { get; set; }

    public LegendModel? Legend { get; set; }

    /// <summary>
    /// Optional ARIA role attribute.
    /// </summary>
    public string? Role { get; set; }

    public class LegendModel : GdsWithContent
    {
        /// <summary>
        /// Whether the legend also acts as the heading for the page.
        /// </summary>
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
        public static implicit operator LegendModel(HTML s) => new(s);
    }
}
