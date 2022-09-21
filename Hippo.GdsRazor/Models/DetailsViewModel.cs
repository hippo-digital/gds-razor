using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

/// <summary>
/// Make a page easier to scan by letting users reveal more detailed information only if they need it.
/// </summary>
public class DetailsModel : GdsWithContent
{
    /// <summary>
    /// Content to use within the summary element (the visible part of the details element).
    /// </summary>
    public GdsContent? Summary { get; set; }

    /// <summary>
    /// If true, details element will be expanded.
    /// </summary>
    public bool Open { get; set; }

    public DetailsModel()
    {
    }

    public DetailsModel(GdsContent summary, GdsContent content) : base(content)
    {
        Summary = summary;
    }
}
