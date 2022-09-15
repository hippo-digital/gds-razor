using GdsRazor.Models.Content;

namespace GdsRazor.Models.Base;

public abstract class GdsWithHref : GdsWithContent
{
    public string? Href { get; set; }

    public GdsWithHref()
    {
    }

    public GdsWithHref(GdsContent content) : base(content)
    {
    }
}