using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models.Base;

public abstract class GdsWithHref : GdsWithContent
{
    /// <summary>
    /// The value of the link's href attribute.
    /// </summary>
    public string? Href { get; set; }

    public GdsWithHref()
    {
    }

    public GdsWithHref(GdsContent content) : base(content)
    {
    }
}