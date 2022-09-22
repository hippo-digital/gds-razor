using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

/// <summary>
/// Use this component at the top of a page to summarise any errors a user has made.
///
/// When a user makes an error, you must show both an error summary and an error message next to each answer that contains an error.
/// </summary>
public class ErrorSummaryModel : GdsViewModel
{
    /// <summary>
    /// Content to use for the heading of the error summary block.
    /// </summary>
    public GdsContent? Title { get; set; }

    /// <summary>
    /// Content to use for the description of the errors.
    /// </summary>
    public GdsContent? Description { get; set; }

    /// <summary>
    /// The list of errors to include in the summary.
    /// </summary>
    public List<ErrorModel>? ErrorList { get; set; }

    /// <summary>
    /// Prevent moving focus to the error summary when the page loads.
    /// </summary>
    public bool? DisableAutoFocus { get; set; }
    
    public ErrorSummaryModel()
    {
    }

    public ErrorSummaryModel(GdsContent title, List<ErrorModel> errorList) : this()
    {
        Title = title;
        ErrorList = errorList;
    }

    public ErrorSummaryModel(GdsContent title, params ErrorModel[] errorList) : this(title, errorList.ToList())
    {
    }

    public class ErrorModel : GdsWithHref
    {
        public ErrorModel()
        {
        }

        public ErrorModel(GdsContent content) : base(content)
        {
        }

        public static implicit operator ErrorModel(string s) => new(s);
        public static implicit operator ErrorModel(HTML s) => new(s);
        public static implicit operator ErrorModel((string, string) t) => new(t.Item2) { Href = t.Item1 };
    }
}
