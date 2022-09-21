using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

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

    public static implicit operator SkipLinkModel(string s) => new(s);
}
