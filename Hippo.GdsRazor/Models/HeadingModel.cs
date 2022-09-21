using Hippo.GdsRazor.Models.Base;

namespace Hippo.GdsRazor.Models;

public class HeadingModel : GdsWithContent
{
    /// <summary>
    /// Heading level, from 1 to 6.
    /// </summary>
    public int? HeadingLevel { get; set; }
}
