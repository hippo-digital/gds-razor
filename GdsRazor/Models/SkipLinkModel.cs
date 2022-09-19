using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

/// <summary>
/// Use the skip link component to help keyboard-only users skip to the main content on a page.
/// </summary>
public class SkipLinkModel : GdsWithHref
{
    public SkipLinkModel()
    {
    }

    public SkipLinkModel(GdsContent content) : base(content)
    {
    }
}
